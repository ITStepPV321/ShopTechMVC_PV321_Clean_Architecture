using DataAccess.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using ShopTechMVC_PV321.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Sevices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("ShopTechMVC_PV321ContextConnection");
builder.Services.AddDbContext<ShopTechMVCDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddDefaultIdentity<AppUser>(options=>options.SignIn.RequireConfirmedAccount=true)
    .AddRoles<IdentityRole>()            
    .AddEntityFrameworkStores<ShopTechMVCDbContext>();

//add FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

//add Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { 
    options.IdleTimeout = TimeSpan.FromSeconds(100);
    options.Cookie.Name = "_ShopTechMVC_PV321.Session";
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
});
//The build-in IoC containar supports three kinds og lifitimes
// Singelton  - при першому запиті стоврюється один обєк для всії
// Transient - при кожному звернені створюється новий обєкт.
// Scoped - стоврення обєкта сервісу для кожного запиту (controller=> action)
//add remode service
builder.Services.AddScoped<IProductsService,ProductsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) { 
 var serviceProvider= scope.ServiceProvider;
    //передали обєкт ServiceProvider класу ініціалізтора
    Seeder.SeedRoles(serviceProvider).Wait();
    Seeder.SeedAdmin(serviceProvider).Wait();
}
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

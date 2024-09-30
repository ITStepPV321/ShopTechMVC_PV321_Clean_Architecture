using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace ShopTechMVC_PV321.Helpers
{
	public enum Roles { 
		User,
		Admin
	}
	public static class Seeder
	{ //інєкція  відбувається у класі ініціалізатора 

		public static async Task SeedRoles(this IServiceProvider appServices) {
			//не можна виклористовувати інєкцію залежностей, тому виуористовуємо метод Get...
			//отримуємо можливість працювати із ролями
			var roleManager= appServices.GetRequiredService<RoleManager<IdentityRole>>();
			foreach (var role in Enum.GetNames(typeof(Roles)))
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new IdentityRole(role));
				}
			}

		}

		public static async Task SeedAdmin(this IServiceProvider appServices) { 
			//лтримуємо можливість роботи із користувачами
			var userManager= appServices.GetRequiredService<UserManager<AppUser>>();
			const string USERNAME = "admin@admin.com";
			const string PASSWORD = "Qwerty-1";

			var existingUser=userManager.FindByNameAsync(USERNAME).Result;
			if (existingUser == null) {
				var user = new AppUser
				{
					UserName = USERNAME,
					Email = USERNAME
				};

				var result=userManager.CreateAsync(user,PASSWORD).Result;
				if (result.Succeeded) {
					userManager.AddToRoleAsync(user, "Admin").Wait();
				}
			
			}




		}
		


		}
}

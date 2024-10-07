using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopTechMVC_PV321.Validation;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Interfaces;
using BusinessLogic.DTOs;

namespace ShopTechMVC_PV321.Controllers
{
    //[Authorize(Roles = "Admin")]
    //[Authorize(Roles ="Admin, Manager")]
    //[Authorize(Roles = "Manager")]
    public class ProductController : Controller
    {
        //private readonly List<Product> _products;
        //private readonly ShopTechMVCDbContext _context = new ShopTechMVCDbContext();
        private readonly ShopTechMVCDbContext _context;
        private readonly IProductsService _productsService;
        public ProductController(ShopTechMVCDbContext context, IProductsService productsService)
        {
            //_products = SeedData.GetProduct();
            _context = context;
            _productsService = productsService; 
        }
        
        public IActionResult Index()
        {
            //TODO: dbcontext
            //return View(_products);
            var products = _productsService.GetAll();
            return View(products);
        }

        //public IActionResult Details(int id)
        //{
        //    //var id =int.Parse(HttpContext.Request.Query["id"]);
        //    var product = _products.FirstOrDefault(p => p.Id == id);
        //    return View(product);

        //}
        [AllowAnonymous]
        //[Route("Product/Details2/{id:int}")]
        [Route("Product/Details/{id:int}")]
        public IActionResult Details(int id, string? returnUri=null)
        {
            //https://localhost:7001/Product/Details?id=1
            // var id = int.Parse(Request.Query["id"]);
            //https://localhost:7001/Product/Details/1
            // var id = int.Parse(RouteData.Values["id"].ToString());

            //var product = _products.FirstOrDefault(p => p.Id == id);
            ViewBag.ReturnUri = returnUri;
            //var product = _context.Products.FirstOrDefault(p => p.Id == id);
            var product = _productsService.GetById(id);
            return View(product);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id) {
            //find in database
            //var product = _products.FirstOrDefault(product => product.Id == id);
            //var product = _context.Products.FirstOrDefault(product => product.Id == id);
            //if (product != null) {
            //    ////_products.Remove(product);
            //    _context.Products.Remove(product);
            //    _context.SaveChanges();
            //}
            _productsService.Delete(id);
         
            //return View("Index",_products);
            return View("Index",_productsService.GetAll());
        }

        [HttpGet]
        public IActionResult Create() {
            var categories = _productsService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto product) {
            //level Property (All)
            if (product.Price == 999)
                ModelState.AddModelError("Price", "999 -  not correct data");
            //level Model (ModelOnly)
            if (product.Title == product.Description)
                ModelState.AddModelError("", "Назва Title не повинна співпадати з Description");
            
            if (!ModelState.IsValid) {
                string errorMessage = "";
                foreach (var item in ModelState)
                {
                    if (item.Value.ValidationState == ModelValidationState.Invalid)
                    {
                        errorMessage = $"{errorMessage} \n Errros for prop {item.Key}\n";
                        //перебираємо всі помилки
                        foreach (var error in item.Value.Errors)
                        {
                            errorMessage = $"{errorMessage}{error.ErrorMessage}\n";
                        }
                    }
                }


                var categories = _productsService.GetAllCategories();
                ViewBag.Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
                ViewBag.ErrorMessage=errorMessage;
                return View(product);
            }
            //_context.Products.Add(product);
            //_context.SaveChanges(true);
            _productsService.Create(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {   //Request.Form
            //RouteData.Values["id"] = id;
            //Request.Query["id"] = id;
            //var product = _context.Products.FirstOrDefault(x => x.Id == id);
            var product=_productsService.GetById(id);
            if (product != null)
            {
                var categories = _productsService.GetAllCategories();
                ViewBag.Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ProductDto product) // Product.Title =Title... 
        {
            //var validator = new ProductValidator();
           // var result= validator.Validate(product);
           // if(!result.IsValid)
            if (!ModelState.IsValid)
            {
                var categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
                return View(product);
            }
            _productsService.Edit(product);
            //_context.Products.Update(product);
            //_context.SaveChanges(true);
            return RedirectToAction("Index");
        }

    }
}

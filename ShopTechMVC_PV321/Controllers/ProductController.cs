using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopTechMVC_PV321.Controllers
{
    public class ProductController : Controller
    {
        //private readonly List<Product> _products;
        //private readonly ShopTechMVCDbContext _context = new ShopTechMVCDbContext();
        private readonly ShopTechMVCDbContext _context;
        public ProductController(ShopTechMVCDbContext context)
        {
            //_products = SeedData.GetProduct();
            _context = context;
        }
        public IActionResult Index()
        {
            //TODO: dbcontext
            //return View(_products);
            var products = _context.Products.Include(product=>product.Category).ToList<Product>();
            return View(products);
        }

        //public IActionResult Details(int id)
        //{
        //    //var id =int.Parse(HttpContext.Request.Query["id"]);
        //    var product = _products.FirstOrDefault(p => p.Id == id);
        //    return View(product);

        //}
        //[Route("Product/Details2/{id:int}")]
        [Route("Product/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            //https://localhost:7001/Product/Details?id=1
            // var id = int.Parse(Request.Query["id"]);
            //https://localhost:7001/Product/Details/1
            // var id = int.Parse(RouteData.Values["id"].ToString());

            //var product = _products.FirstOrDefault(p => p.Id == id);
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return View(product);

        }
        public IActionResult Delete(int id) { 
            //find in database
            //var product = _products.FirstOrDefault(product => product.Id == id);
            var product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product != null) {
                //_products.Remove(product);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
         
            //return View("Index",_products);
            return View("Index",_context.Products.ToList<Product>());
        }

        [HttpGet]
        public IActionResult Create() {
            var categories = _context.Categories.ToList();
            ViewBag.ListCategories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
            return View();
        }


    }
}

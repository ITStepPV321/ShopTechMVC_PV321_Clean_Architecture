using Microsoft.AspNetCore.Mvc;
using ShopTechMVC_PV321.Helpers;
using ShopTechMVC_PV321.Models;

namespace ShopTechMVC_PV321.Controllers
{
    public class ProductController : Controller
    {
        private readonly List<Product> _products;
        public ProductController()
        {
            _products = SeedData.GetProduct();
        }
        public IActionResult Index()
        {
            //TODO: dbcontext
            return View(_products);
        }
        
        public IActionResult Details(int id)
        {
            //var id =int.Parse(HttpContext.Request.Query["id"]);
            var product = _products.FirstOrDefault(p => p.Id == id);
            return View(product);

        }
        public IActionResult Delete(int id) { 
            //find in database
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product != null) {
                _products.Remove(product);
            }
            return View("Index",_products);
        }
    }
}

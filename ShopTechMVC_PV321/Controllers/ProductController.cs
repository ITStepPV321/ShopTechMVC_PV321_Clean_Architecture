using Microsoft.AspNetCore.Mvc;
using ShopTechMVC_PV321.Models;

namespace ShopTechMVC_PV321.Controllers
{
    public class ProductController : Controller
    {
        private readonly List<Product> _products;
        public ProductController()
        {
            _products = new List<Product>();
        }
        public IActionResult Index()
        {
            //TODO: dbcontext
            return View(_products);
        }
    }
}

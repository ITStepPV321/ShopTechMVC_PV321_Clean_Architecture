using Microsoft.AspNetCore.Mvc;
using ShopTechMVC_PV321.Helpers;
using ShopTechMVC_PV321.Models;
using System.Diagnostics;

namespace ShopTechMVC_PV321.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Product> _products;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _products = new List<Product>(SeedData.GetProduct());
        }
        //ViewData, ViewBag, ModelView
        //https://localhost:7001/Home/Index 
        //https://localhost:7001/ 
        public IActionResult Index()
        {
            ViewData["message"] = "We are learning...";
            ViewBag.Users = new List<string> { "Admin", "Author", "Guest" };  
            return View(_products);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult About() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

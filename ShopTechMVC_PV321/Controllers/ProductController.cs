﻿using Microsoft.AspNetCore.Mvc;
using ShopTechMVC_PV321.Data;
using ShopTechMVC_PV321.Helpers;
using ShopTechMVC_PV321.Models;

namespace ShopTechMVC_PV321.Controllers
{
    public class ProductController : Controller
    {
        private readonly List<Product> _products;
        private readonly ShopTechMVCDbContext _context = new ShopTechMVCDbContext();

        public ProductController()
        {
            //_products = SeedData.GetProduct();
        }
        public IActionResult Index()
        {
            //TODO: dbcontext
            //return View(_products);
            return View(_context.Products.ToList<Product>());
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
    }
}

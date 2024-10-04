using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTechMVC_PV321.Helpers;

namespace ShopTechMVC_PV321.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService= cartService;
            
        }
        public IActionResult Index()
        {
          return View(_cartService.GetProducts()); //List<ProductDto>
         }

        public IActionResult Add(int id)
        {
            _cartService.Add(id);   
            return RedirectToAction("Index","Home");
        }


        public IActionResult Delete(int id)
        {
           _cartService.Remove(id);

            return RedirectToAction("Index");
        }
    }
    //using Dictionary
    // plusCountProduct(int id)
    // minusCountProduct(int id)
}

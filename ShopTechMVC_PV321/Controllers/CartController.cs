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
          return View(_cartService.GetProducts());
         }

        public IActionResult Add(int id)
        {
            _cartService.Add(id);   
            return RedirectToAction("Index","Home");
        }


        public IActionResult Delete(int id)
        {
            if (_context.Products.Find(id) == null)
            {
                return null;
            }

            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart")!;

            if (idList == null)
            {
                idList = new List<int>();
            }

            idList.Remove(id);

            HttpContext.Session.SetObject<List<int>>("mycart", idList);

            return RedirectToAction("Index");
        }
    }
    //using Dictionary
    // plusCountProduct(int id)
    // minusCountProduct(int id)
}

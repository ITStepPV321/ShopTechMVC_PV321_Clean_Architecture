using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ShopTechMVC_PV321.Helpers;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ShopTechMVC_PV321.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ShopTechMVCDbContext _context;
        private readonly IMailService _mailService;


        public OrderController(ShopTechMVCDbContext context, IMailService mailService) {
            _context = context;
            _mailService = mailService;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            string? userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders=_context.Orders.Where(o => o.AppUserId == userId).ToList();
             return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public async Task<ActionResult> Create()
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("mycart");
            if (ids == null) return BadRequest();
			var products = _context.Products.Include(p => p.Category).Where(p => ids.Contains(p.Id)).ToList();
			string? userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Order newOrder = new()
            { OrderDate = DateTime.Now,
                IdsProduct = HttpContext.Session.GetString("mycart"),
                TotalPrice= products.Sum(p => p.Price),
                AppUserId = userId,

			};
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            HttpContext.Session.Clear();    
            //send to email
            string? userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var orders  = _context.Orders.Where(o => o.AppUserId == userId).ToList(); ;
            string text = "";
            foreach (var item in orders)
            {
                text += $"{item.Id} {item.OrderDate}  {item.TotalPrice}\n";

            }
            await _mailService.SendMailAsync("Your Order", text, "velos72416@rowplant.com");
            await _mailService.SendMailAsync("Your Order", text,userName!);



			return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

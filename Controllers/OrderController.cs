using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrialLoginAndRegistrationWeb.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TrialLoginAndRegistrationWeb.Controllers
{
    public class OrderController : Controller
    {
        ApplicationContext db;
        public OrderController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Orders.ToArrayAsync());
        }
        public async Task<IActionResult> Booking()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else {return Challenge(); }  
        }

        [HttpPost]
        public async Task<IActionResult> Booking(Order order, int? id)
        {
            //OrderAndClothes? orderAndClothes = await db.Clothes.FirstOrDefaultAsync(f => f.Clothes_ID == id);
            Clothes? clothes = await db.Clothes.FirstOrDefaultAsync(p => p.Clothes_ID == id);
            
            //Clothes clothes = new Clothes();
            order.Order_UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.Order_ClothesID = clothes.Clothes_ID;
            order.Order_Date = DateTime.Now;
            order.Order_Sum = clothes.Price;
            order.Order_Perfomance = "Proccesing";
            if (order.Order_RentDate <= DateTime.Now)
            {
                //ModelState.AddModelError("Order_RentDate", "Error message");
                return RedirectToAction("Booking");
            }
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Order order = new Order { Order_ID = id.Value };
                db.Entry(order).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}

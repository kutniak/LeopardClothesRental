using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrialLoginAndRegistrationWeb.Models;

namespace TrialLoginAndRegistrationWeb.Controllers
{
    public class ClothesController : Controller
    {
        ApplicationContext db;
        public ClothesController (ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Clothes.ToArrayAsync());
        }
        /*
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (Clothes clothes, IFormFile file)
        {
            if(file != null && file.Length >0)
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                clothes.Foto = stream.ToArray();
            }

            db.Clothes.Add(clothes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Clothes clothes = new Clothes { Clothes_ID = id.Value };
                db.Entry(clothes).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit (int? id)
        {
            if (id != null)
            {
                Clothes? clothes = await db.Clothes.FirstOrDefaultAsync(p => p.Clothes_ID == id);
                if (clothes != null) return View(clothes);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit (Clothes clothes)
        {
            db.Clothes.Update(clothes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        */

        public async Task<IActionResult> ViewClothes (int? id)
        {
            if (id != null)
            {
                Clothes? clothes = await db.Clothes.FirstOrDefaultAsync(p => p.Clothes_ID == id);
                if (clothes != null) return View(clothes);
            }
            return NotFound();
        }
    }
}

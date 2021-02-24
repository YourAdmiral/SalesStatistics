using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesStatistics.Models;

namespace SalesStatistics.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly SalesDbContext _db;

        [BindProperty]
        public Sale Sale { get; set; }

        public SalesController(SalesDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Upsert(int? id)
        {
            Sale = new Sale();
            if (id == null)
            {
                return View(Sale);
            }

            Sale = _db.Sales.FirstOrDefault(u => u.Id == id);
            if (Sale == null)
            {
                return NotFound();
            }
            return View(Sale);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Sale.Id == 0)
                {
                    _db.Sales.Add(Sale);
                }
                else
                {
                    _db.Sales.Update(Sale);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Sale);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Sales.ToListAsync() });
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Sales.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Sales.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}

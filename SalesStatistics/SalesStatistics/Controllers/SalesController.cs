using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesStatistics.Models;

namespace SalesStatistics.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Sales.ToListAsync() });
        }

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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SalesStatistics.Models;

namespace SalesStatistics.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
		private readonly SalesDbContext _db;

		public HomeController(SalesDbContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			int currentYear = DateTime.Now.Year;

			List<DataPoint> dataPoints = new List<DataPoint>{
				new DataPoint(1, 0),
				new DataPoint(2, 0),
				new DataPoint(3, 0),
				new DataPoint(4, 0),
				new DataPoint(5, 0),
				new DataPoint(6, 0),
				new DataPoint(7, 0),
				new DataPoint(8, 0),
				new DataPoint(9, 0),
				new DataPoint(10, 0),
				new DataPoint(11, 0),
				new DataPoint(12, 0)
			};

			foreach (var dataPoint in dataPoints)
            {
                foreach (var sale in _db.Sales)
                {
                    if (sale.Date.Year == currentYear 
						&& sale.Date.Month == dataPoint.X)
                    {
						dataPoint.Y += sale.Cost;
					}
				}
            }

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}
	}
}

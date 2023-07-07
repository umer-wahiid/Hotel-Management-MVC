using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HManagement.Models;

namespace HManagement.Controllers
{
    public class AdminsController : Controller
    {

		private HotelContext db = new HotelContext();

		// GET: Admins
		public ActionResult Index()
        {
			var role = Convert.ToInt32(Session["R"]);

			DateTime currentDate = DateTime.Now.Date;
			DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
			DateTime endDate = startDate.AddMonths(1).AddDays(-1);
			//DateTime currentDay = DateTime.Now.Date;

			//var user = Session["id"];
			//var name = Se;
			//var Co = HttpContext.Session.GetInt32("Co");
			//var Dr = HttpContext.Session.GetInt32("Dr");
			int Allcount = db.Bookings.Count(z => z.UserId != null);
			int Allday = db.Bookings.Count(z => z.UserId != null && z.CheckIn == currentDate);
			int Allmonth = db.Bookings.Count(z => z.UserId != null && z.CheckIn >= startDate && z.CheckIn <= endDate);
			ViewBag.SD = startDate;
			ViewBag.ED = endDate;
			ViewBag.count = Allcount;
			ViewBag.day = Allday;
			ViewBag.month = Allmonth;



			if (Convert.ToInt32(Session["R"]) != 0){
				var bookings = db.Bookings.ToList();
                return View(bookings);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
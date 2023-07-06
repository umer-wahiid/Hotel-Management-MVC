using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HManagement.Models;


namespace HManagement.Controllers
{
    public class HomeController : Controller
    {
        private HotelContext db = new HotelContext();

        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult Room(string rm)
        {
            if (rm != null)
            {
                var room = db.Rooms.Where(a=>a.RoomType==rm).ToList();
                return View(room);
            }
            else
            {
                var room = db.Rooms.ToList();
                return View(room);
            }
        }
    }
}
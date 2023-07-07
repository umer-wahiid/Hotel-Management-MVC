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
        public ActionResult Gallery()
        {
            return View();
        }
       
        public ActionResult Bookings()
        {
            var id = Convert.ToInt32(Session["id"]);
            var booking = db.Bookings.Where(a=> a.UserId == id).ToList();
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult Room(string rm)
        {
            if (rm != null)
            {
                var room = db.Rooms.Where(a=>a.RoomType==rm && a.Availability=="Available").ToList();
                return View(room);
            }
            else
            {
                var room = db.Rooms.Where(a =>a.Availability == "Available").ToList();
                return View(room);
            }
        }
    }
}
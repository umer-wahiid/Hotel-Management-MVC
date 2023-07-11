using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HManagement.Models;
using Microsoft.Ajax.Utilities;

namespace HManagement.Controllers
{
    public class BookingsController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Bookings
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["R"]) != 0)
            {
                return View(db.Bookings.ToList());
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create(int? id)
        {
            if (Session["id"] != null)
            {
                var room = db.Rooms.FirstOrDefault(a => a.RoomId == id);
                ViewBag.RT = room.RoomType;
                ViewBag.RN = room.RoomNo;
                ViewBag.RP = room.Price;
                ViewBag.RI = room.image_path;
                ViewBag.UI = Session["id"];
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,Nights,CheckIn,CheckOut,RoomType,RoomNo,Confirm,Payment,Total,UserId,Image")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                
                
                var room = db.Rooms.Where(c => c.RoomNo == booking.RoomNo);
                room.ForEach(c => c.Availability = "Unavailable");
                db.SaveChanges();

                return RedirectToAction("Bookings", "Home");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Nights,CheckIn,CheckOut,RoomType,RoomNo,Confirm,Payment,Total")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }



        // GET: Bookings/Delete/5
        public ActionResult EditPayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPayment(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking != null)
            {
                booking.Payment = "Online";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        
        // GET: Bookings/Delete/5
        public ActionResult EditConfirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking != null)
            {
                booking.Confirm = "Confirmed";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        
        






        // GET: Bookings/Delete/5
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking != null)
            {
                booking.Confirm = "Completed";
                booking.Payment = "Online";
                db.SaveChanges();


                var room = db.Rooms.Where(c => c.RoomNo == booking.RoomNo);
                room.ForEach(c => c.Availability = "Available");
                db.SaveChanges();
                
                return RedirectToAction("Index");

            }
            return HttpNotFound();
        }
















        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();

            var room = db.Rooms.Where(c => c.RoomNo == booking.RoomNo);
            room.ForEach(c => c.Availability = "Available");
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

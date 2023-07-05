using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HManagement.Models;

namespace HManagement.Controllers
{
    public class UsersController : Controller
    {

        HotelContext HC = new HotelContext();
        // GET: Users
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            HC.Users.Add(user);
            HC.SaveChanges();
            //TempData["rtrn"] = "< script >alert('Data Inserted Successfully !!')</ script >";
            TempData["rtrn"] = "<script>alert('Data Inserted Successfully !!')</script>";
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Edit(int? id)
        {
            var registration = HC.Users.Find(id);
            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                HC.Entry(user).State = EntityState.Modified;
                HC.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(user);
            //TempData["rtrn"] = "< script >alert('Data Inserted Successfully !!')</ script >";
            //TempData["rtrn"] = "<script>alert('Data Inserted Successfully !!')</script>";
            //return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var x = from a in HC.Users where a.UEmail.Equals(user.UEmail) && a.Password.Equals(user.Password) select a;
            if (x.Any())
            {
                User use = HC.Users.Where(c => c.UEmail == user.UEmail).FirstOrDefault();
                if (use.Role == 0)
                {
                    TempData["wel"] = "<script>alert('Welcome !!')</script>";
                    Session["id"] = use.UserId;
                    Session["N"] = use.UName;
                    Session["E"] = use.UEmail;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Admins");
                }
            }
            else
            {
                TempData["error"] = "<script>alert('Wrong Credentials !!')</script>";
                return View();
            }
        }

    }
}
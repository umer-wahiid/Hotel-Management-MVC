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
        public ActionResult Index()
        {
            var user = HC.Users.Where(a => a.Role == 0);
            return View(user.ToList());
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                HC.Users.Add(user);
                HC.SaveChanges();
                //TempData["rtrn"] = "< script >alert('Data Inserted Successfully !!')</ script >";
                TempData["rtrn"] = "<script>alert('Data Inserted Successfully !!')</script>";
                return RedirectToAction("Index", "Home");
            }
            return View(user);
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
        }

        //[OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home", new { rnd = DateTime.Now.Ticks });
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
                    //TempData["wel"] = "<script>alert('Welcome !!')</script>";
                    Session["id"] = use.UserId;
                    Session["N"] = use.UName;
                    Session["E"] = use.UEmail;
                    Session["R"] = use.Role;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //TempData["wel"] = "<script>alert('Welcome !!')</script>";
                    Session["id"] = use.UserId;
                    Session["N"] = use.UName;
                    Session["E"] = use.UEmail;
                    Session["R"] = use.Role;
                    return RedirectToAction("Index", "Admins");
                }
            }
            else
            {
                TempData["error"] = "Wrong Credentials !!";
                return View();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HManagement.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (Convert.ToInt32(Session["R"]) != 0){
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
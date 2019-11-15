using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public void OnPost()
        {
            var weight = Request.Form["weight"];
            // do something with weight
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "All Bookings";

            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
    }
}
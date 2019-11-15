using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Controllers
{
    public class HomeController : Controller
    {
        public List<Airport> Nodes { get; set; }

        public ActionResult Index()
        {
            var helper = new DatabaseHelper();
            var airports = helper.GetaAirports();

            ViewBag.Airports = airports;

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
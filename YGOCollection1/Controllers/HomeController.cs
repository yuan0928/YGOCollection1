using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace YGOCollection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult MainPage()
        {
            return View();
        }
        public ActionResult AddCard()
        {
            return View();
        }
        public ActionResult FullCard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.test = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
            return View();
        }
    }
}
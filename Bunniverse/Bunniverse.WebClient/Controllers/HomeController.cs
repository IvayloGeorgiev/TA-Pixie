using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bunniverse;
using Bunniverse.MongoDatabase;

namespace Bunniverse.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dbFactory = new BunniverseFactory();
            ViewBag.Message = dbFactory.GenerateMongoData();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

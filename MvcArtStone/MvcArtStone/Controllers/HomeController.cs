using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcArtStone.Models;

namespace MvcArtStone.Controllers
{
    public class HomeController : Controller
    {
        private readonly LogicBehind.ArtworkLogic _LogicBehind;
        public HomeController()
        {
            _LogicBehind = new LogicBehind.ArtworkLogic();

        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Submit(Artwork model) //(Models.Artwork model)
        {
            //_artworkMaster.AddArtwork(model);
            //model = new Artwork("test","test");
            LogicBehind.ArtworkLogic.AddArtwork(model);
            return Content("Sucess!");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Manager()
        {
            ViewBag.Message = "Manager Page";
            return View();
        }
    }
}
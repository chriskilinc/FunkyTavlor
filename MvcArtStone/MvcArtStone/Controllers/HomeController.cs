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
            var model = _LogicBehind.GetArtowrkInFatList();
            return View(model);
        }

        [HttpPost]
        public ActionResult InsertArtwork(MvcArtStone.Models.Artwork model)
        {
            MvcArtStone.LogicBehind.ArtworkLogic.AddArtwork(model);
            return Content("Success!");
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
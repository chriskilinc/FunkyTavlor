using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcArtStone.Models;
using Newtonsoft.Json;

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
        public ActionResult EditArtwork(string id)
        {
            var singleArtwork = new Artwork();
            singleArtwork = _LogicBehind.GetSingleArtworkById(id);
            return View(singleArtwork);
        }

        public ActionResult GetArtworks()
        {
            var artworksList = _LogicBehind.GetArtworkskInFatList();
            return Json(artworksList, JsonRequestBehavior.AllowGet);
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
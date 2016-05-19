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

        [HttpGet]
        public ActionResult EditArtwork(Guid id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult GetSingleArtworkByKey(string key)
        {
            
            Artwork artwork = _LogicBehind.GetSingleArtworkById(key);
            return Json(artwork);
        }

        public ActionResult GetArtworks()
        {
            var artworksList = _LogicBehind.GetArtworkskInFatList();
            return Json(artworksList, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult InsertArtwork(ArtworkInsertModel model)
        {
            MvcArtStone.LogicBehind.ArtworkLogic.AddArtwork(model);
            return Content("Success!");
        }

        [HttpPost]
        public ActionResult InsertImageWithArtwork(HttpPostedFile file)
        {
            LogicBehind.ArtworkLogic.AddImage(file);
            return Content("Image was uploaded");
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
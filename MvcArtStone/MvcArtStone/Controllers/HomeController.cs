﻿using System;
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

        //Exikveras när EditArtwork sidan laddas, och hämtar konstverkets ID(Guid) från URL
        public ActionResult EditArtwork(Guid id)
        {
            //Kallar på GetArtworkByKey metoden och skickar in ett id som parameter
            MvcArtStone.Models.Artwork TheArtwork = GetArtworkByKey(id.ToString());
            //GetArtworkByKey kommer nu innehålla ett konstverk
            //Skicka TheArtwork till EditArtwork vyn5
            return View(TheArtwork);
        }

        [HttpPost]
        public ActionResult EditArtworkByModel(Artwork model)
        {
            _LogicBehind.EditArtworkUsingModel(model);
            return Content("SUCCESS");
        }
        //[HttpPost]
        //public ActionResult GetSingleArtworkByKey(string key)
        //{

        //    Artwork artwork = _LogicBehind.GetSingleArtworkById(key);
        //    return Json(artwork);
        //}

        public ActionResult GetArtworkByKey()
        {
            return View("EditArtwork");
        }

        public Artwork GetArtworkByKey(string key)
        {
            //Tar emot ett ID från EditArtwork och går sedan in i databasen och hämtar konstverket med det ID't
            var artwork = _LogicBehind.GetSingleArtworkById(key);
            //Skickar tillbaks ett Json objekt med konstverket
            return artwork;
        }

        public ActionResult GetArtworks()
        {
            var artworksList = _LogicBehind.GetArtworkskInFatList();
            return Json(artworksList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllArtworks()
        {
            var fullArtworkList = _LogicBehind.GetFullArtworkList();
            return Json(fullArtworkList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertArtwork(ArtworkInsertModel model)
        {
            MvcArtStone.LogicBehind.ArtworkLogic.AddArtwork(model);
            return Content("Success!");
        }

        [HttpPost]
        public ActionResult DeleteArtworkById(Artwork model)
        {
            if (model != null)
            {
                LogicBehind.ArtworkLogic.DeleteArtworkwithId(model.Id.ToString());
            }

            return Content("Fatality");
        }

        [HttpPost]
        public ActionResult DestroyArtworkById(Artwork model)
        {
            if (model != null)
            {
                LogicBehind.ArtworkLogic.DestroyArtworkById(model.Id.ToString());
            }
            return Content("Artwork removed from database");
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

        public ActionResult Admin()
        {
            ViewBag.Message = "Administrative Page";
            return View();
        }

        [HttpPost]
        public ActionResult SearchArtworks(string id)
        {
            var artworks = _LogicBehind.SearchArtworks(id);
            //var companies = _companyBusiness.SearchCompanyHead(id);
            //return Json(artworks, JsonRequestBehavior.AllowGet);
            return Json(artworks, JsonRequestBehavior.AllowGet);
        }
    }
}
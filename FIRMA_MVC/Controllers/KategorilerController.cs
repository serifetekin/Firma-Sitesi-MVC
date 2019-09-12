using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIRMA_MVC.Models;

namespace FIRMA_MVC.Controllers
{
    public class KategorilerController : Controller
    {
        FIRMAMODEL db = new FIRMAMODEL();
        
        // GET: Kategoriler
        public ActionResult Index()
        {
            //var liste = db.KATEGORIs.ToList();
            List<KATEGORI> liste = db.KATEGORIs.ToList();
            //return View();
            return View(liste);
            //return View("Index");
            //return View("Index", liste);
        }
    }
}
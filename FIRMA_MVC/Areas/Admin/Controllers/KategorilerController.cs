﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIRMA_MVC.Models;

namespace FIRMA_MVC.Areas.Admin.Controllers
{
    public class KategorilerController : Controller
    {
        FIRMAMODEL db = new FIRMAMODEL();

        // GET: Kategoriler
        public ActionResult Index(string arama)
        {
            List<KATEGORI> liste = new List<KATEGORI>();
            if (arama==null)
            {
               arama = "";
               liste = db.KATEGORIs.ToList();
            }
            else
            {
               liste = db.KATEGORIs.Where(k => k.KATEGORI_ADI.Contains(arama)).ToList();
            }

            ViewData["veri"] = arama;
            
            return View(liste);
            
        }
        public ActionResult Delete(int id)
        {
            KATEGORI k = db.KATEGORIs.Find(id);
            if (k!=null)
            {
                db.KATEGORIs.Remove(k);
                db.SaveChanges();
            }

            //List<KATEGORI> liste = db.KATEGORIs.ToList();
            //return View("Index",liste);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id==null)
            {
                KATEGORI k = new KATEGORI();
                return View(k);
            }
            else
            {
                KATEGORI k = db.KATEGORIs.Find(id);
                return View(k);
            }
        }

        [HttpPost]
        public ActionResult Create(KATEGORI k)
        {
            if (k.KATEGORI_REFNO==0)
            {
                db.KATEGORIs.Add(k); 
            }
            else
            {
                db.Entry(k).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string txtAra)
        {
            return RedirectToAction("Index", "Kategoriler", new { arama=txtAra });
        }

    }
}
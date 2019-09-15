using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIRMA_MVC.Models;

namespace FIRMA_MVC.Areas.Admin
{
    public class Projeler2Controller : Controller
    {
        FIRMAMODEL db = new FIRMAMODEL();
        // GET: Admin/Projeler2
        public ActionResult Index(string arama)
        {
            List<PROJE> liste = new List<PROJE>();
            if (arama == null)
            {
                arama = "";
                liste = db.PROJEs.ToList();
            }
            else
            {
                liste = db.PROJEs.Where(p => p.PROJE_ADI.Contains(arama)).ToList();
            }

            ViewData["veri"] = arama;

            return View(liste);

        }
        public ActionResult Delete(int id)
        {
            PROJE p = db.PROJEs.Find(id);
            if (p != null)
            {
                db.PROJEs.Remove(p);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                PROJE p = new PROJE();
                return View(p);
            }
            else
            {
                PROJE p = db.PROJEs.Find(id);
                return View(p);
            }
        }

        [HttpPost]
        public ActionResult Create(PROJE proje, HttpPostedFileBase RESIM)
        {
            if (ModelState.IsValid)
            {
                if (proje.PROJE_ADI != null)
                {
                    db.PROJEs.Add(proje);
                }
                if (proje.ACIKLAMA == null)
                {
                    db.PROJEs.Add(proje);
                }
                if (RESIM != null)
                {
                    proje.RESIM = RESIM.FileName;
                }
                
                if (proje.PROJE_REFNO == 0)
                {
                    db.PROJEs.Add(proje);
                }
                else
                {
                    db.Entry(proje).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();


                if (RESIM != null)
                {
                    RESIM.SaveAs(Request.PhysicalApplicationPath + "/images/" + RESIM.FileName); //resim kaydediliyor
                }

            }
            else
            {
                string hatalar = "";
                foreach (var item in ModelState.Values)
                {
                    for (int i = 0; i < item.Errors.Count; i++)
                    {
                        hatalar += item.Errors[i].ErrorMessage;
                    }

                }
                ViewData["hatalar"] = hatalar;
                return View(proje);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Search(string txtAra)
        {
            return RedirectToAction("Index", "Projeler2", new { arama = txtAra });
        }

    }
}

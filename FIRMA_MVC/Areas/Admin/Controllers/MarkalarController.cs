using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIRMA_MVC.Models;

namespace FIRMA_MVC.Areas.Admin
{
    public class MarkalarController : Controller
    {
        FIRMAMODEL db = new FIRMAMODEL();
        // GET: Admin/Markalar
        public ActionResult Index(string arama)
        {
            List<MARKA> liste = new List<MARKA>();
            if (arama == null)
            {
                arama = "";
                liste = db.MARKAs.ToList();
            }
            else
            {
                liste = db.MARKAs.Where(k => k.MARKA_ADI.Contains(arama)).ToList();
            }

            ViewData["veri"] = arama;

            return View(liste);

        }
        public ActionResult Delete(int id)
        {
            MARKA m = db.MARKAs.Find(id);
            if (m != null)
            {
                db.MARKAs.Remove(m);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                MARKA m = new MARKA();
                return View(m);
            }
            else
            {
                MARKA m = db.MARKAs.Find(id);
                return View(m);
            }
        }

        [HttpPost]
        public ActionResult Create(MARKA marka, HttpPostAttribute MARKA_ADI)
        {
            if (ModelState.IsValid)
            {
                if (marka.MARKA_ADI != null)
                {
                    db.MARKAs.Add(marka);
                }
                if (marka.MARKA_REFNO == 0)
                {
                    db.MARKAs.Add(marka);
                }
                else
                {
                    db.Entry(marka).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
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
                return View(marka);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Search(string txtAra)
        {
            return RedirectToAction("Index", "Markalar", new { arama = txtAra });
        }

    }
}

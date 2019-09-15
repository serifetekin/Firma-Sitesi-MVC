using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIRMA_MVC.Models;

namespace FIRMA_MVC.Areas.Admin.Controllers
{
    public class SayfalarController : Controller
    {
        FIRMAMODEL db = new FIRMAMODEL();

        // GET: Admin/Sayfalar
        public ActionResult Index(string arama)
        {
            List<SAYFA> liste = new List<SAYFA>();
            if (arama == null)
            {
                arama = "";
                liste = db.SAYFAs.ToList();
            }
            else
            {
                liste = db.SAYFAs.Where(s => s.BASLIK.Contains(arama)).ToList();
            }

            ViewData["veri"] = arama;

            return View(liste);
        }
        public ActionResult Delete(int id)
        {
            SAYFA s = db.SAYFAs.Find(id);
            if (s != null)
            {
                db.SAYFAs.Remove(s);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                SAYFA s = new SAYFA();
                return View(s);
            }
            else
            {
                SAYFA s = db.SAYFAs.Find(id);
                return View(s);
            }
        }

        [HttpPost]
        public ActionResult Create(SAYFA sayfa)
        {
            if (ModelState.IsValid)
            {
                if (sayfa.BASLIK != null)
                {
                    db.SAYFAs.Add(sayfa);
                }
                if (sayfa.ICERIK != null)
                {
                    db.SAYFAs.Add(sayfa);
                }
                if (sayfa.SAYFA_REFNO == 0)
                {
                    db.SAYFAs.Add(sayfa);
                }
                else
                {
                    db.Entry(sayfa).State = System.Data.Entity.EntityState.Modified;
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
                return View(sayfa);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Search(string txtAra)
        {
            return RedirectToAction("Index", "Sayfalar", new { arama = txtAra });
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIRMA_MVC.Models;

namespace FIRMA_MVC.Areas.Admin.Controllers
{
    public class SliderlarController : Controller
    {
        FIRMAMODEL db = new FIRMAMODEL();

        // GET: Admin/Sliderlar
        public ActionResult Index(string arama)
        {
            List<SLIDER> liste = new List<SLIDER>();
            if (arama == null)
            {
                arama = "";
                liste = db.SLIDERs.ToList();
            }
            else
            {
                liste = db.SLIDERs.Where(s => s.BASLIK.Contains(arama)).ToList();
            }

            ViewData["veri"] = arama;

            return View(liste);

        }
        public ActionResult Delete(int id)
        {
            SLIDER s = db.SLIDERs.Find(id);
            if (s != null)
            {
                db.SLIDERs.Remove(s);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            SLIDER slider = new SLIDER();

            if (id != null)  //günceleme yapılacak
            {
                slider = db.SLIDERs.Find(id);
                if (slider == null)
                {
                    slider = new SLIDER();
                }
            }
            return View(slider);
        }

        [HttpPost]
        public ActionResult Create(SLIDER slider, HttpPostedFileBase RESIM)
        {
            if (ModelState.IsValid)
            {
                if (slider.BASLIK != null)
                {
                    db.SLIDERs.Add(slider);
                }
                if (slider.LINK != null)
                {
                    db.SLIDERs.Add(slider);
                }
                if (RESIM != null)
                {
                    slider.RESIM = RESIM.FileName;
                }
                if (slider.SLIDER_REFNO == 0)
                {
                    db.SLIDERs.Add(slider);
                }
                else
                {
                    db.Entry(slider).State = System.Data.Entity.EntityState.Modified;
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
                return View(slider);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Search(string txtAra)
        {
            return RedirectToAction("Index", "Sliderlar", new { arama = txtAra });
        }

    }
}
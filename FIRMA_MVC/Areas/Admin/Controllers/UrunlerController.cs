using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIRMA_MVC.Models;
namespace FIRMA_MVC.Areas.Admin.Controllers
{
    public class UrunlerController : Controller
    {
        FIRMAMODEL db = new FIRMAMODEL();
        // GET: Admin/Urunler
        public ActionResult Index()
        {
            List<URUN> liste = db.URUNs.ToList();
            return View(liste);
        }

        public ActionResult Delete(int? id)
        {
            if (id!=null)
            {
                URUN u = db.URUNs.Find(id);
                if (u!=null)
                {
                    db.URUNs.Remove(u);
                    db.SaveChanges();
                }
            }

            //var liste = db.URUNs.ToList();
            //return View("Index", liste);
            return RedirectToAction("Index");
        }

        public ActionResult Create(int? id)
        {
            URUN urun = new URUN();

            if (id != null)  //günceleme yapılacak
            {
                urun = db.URUNs.Find(id);
                if (urun == null)
                {
                    urun = new URUN();
                }
            }

            ViewData["kategori"]= db.KATEGORIs.ToList(); //herşey object olarak saklanır
            ViewBag.marka = db.MARKAs.ToList();

            return View(urun);
        }

        [HttpPost]
        public ActionResult Create(URUN urun, HttpPostedFileBase RESIM1, HttpPostedFileBase RESIM2, 
                                              HttpPostedFileBase RESIM3, HttpPostedFileBase RESIM4)
        {

            if (ModelState.IsValid)
            {
                if (RESIM1!=null)
                {
                    urun.RESIM1 = RESIM1.FileName;
                }

                if (RESIM2 != null)
                {
                    urun.RESIM2 = RESIM2.FileName;
                }
                if (RESIM3 != null)
                {
                    urun.RESIM3 = RESIM3.FileName;
                }
                if (RESIM4 != null)
                {
                    urun.RESIM4 = RESIM4.FileName;
                }

                if (urun.URUN_REFNO == 0)
                {
                    db.URUNs.Add(urun);
                }
                else
                {
                    db.Entry(urun).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                if (RESIM1 != null)
                {
                    RESIM1.SaveAs(Request.PhysicalApplicationPath + "/images/" + RESIM1.FileName); //resim kaydediliyor
                }
                if (RESIM2 != null)
                {
                    RESIM2.SaveAs(Request.PhysicalApplicationPath + "/images/" + RESIM2.FileName);
                }
                if (RESIM3 != null)
                {
                    RESIM3.SaveAs(Request.PhysicalApplicationPath + "/images/" + RESIM3.FileName);
                }
                if (RESIM4 != null)
                {
                    RESIM4.SaveAs(Request.PhysicalApplicationPath + "/images/" + RESIM4.FileName);
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
                ViewData["kategori"] = db.KATEGORIs.ToList(); //herşey object olarak saklanır
                ViewBag.marka = db.MARKAs.ToList();
                return View(urun);
            }


            #region
            //try
            //{
            //}
            //catch (DbEntityValidationException e)
            //{
            //    string sonuc = "";
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        sonuc+= String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            sonuc += String.Format("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }

            //}


            //dosyaları yükle
            #endregion

           
            return RedirectToAction("Index");
        }

        public ActionResult Search(string ara)
        {
            return View();
        }

    }
}
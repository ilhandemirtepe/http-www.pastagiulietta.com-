using PastaMVC.Models;
using PastaMVC.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PastaMVC.Controllers
{
    public class UrunCRUDController : BaseController
    {


        PastaDBEntities db = new PastaDBEntities();
        public ActionResult LogOut()
        {

            return RedirectToAction("Index", "Login");

        }
        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }

      
        public ActionResult Create()
        {
            ViewBag.Kategoriid = new SelectList(db.Kategori, "Kategoriid", "KategoriName");
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product t, HttpPostedFileBase file)
        {

            if (file != null)
            {
                string ds = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/UrunResimleri/");
                file.SaveAs(p + file.FileName);
                using (db)
                {
                    t.ProductResim= file.FileName;
                    db.Product.Add(t);
                    db.SaveChanges();
                }
                ViewBag.Kategoriid = new SelectList(db.Kategori, "Kategoriid", "KategoriName",t.Kategoriid);
            }
            else
            {
                return Content("resim yükle");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            Product stylemaster = db.Product.Find(id);
            if (stylemaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategoriid = new SelectList(db.Kategori, "Kategoriid", "KategoriName", stylemaster.Kategoriid);
            return View(stylemaster);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Product t, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string sd = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/UrunResimleri/");
                file.SaveAs(p + file.FileName);
            }

            using (db)
            {

                t.ProductResim = file.FileName;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

            }
            ViewBag.Kategoriid = new SelectList(db.Kategori, "Kategoriid", "KategoriName", t.Kategoriid);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            return View(db.Product.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Product movie = db.Product.Find(id);
            db.Product.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

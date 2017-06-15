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
    public class KategoriCRUDController : BaseController
    {
        //
        // GET: /KategoriCRUD/
        public ActionResult LogOut()
        {

            return RedirectToAction("Index", "Login");

        }

        PastaDBEntities db = new PastaDBEntities();
        public ActionResult Index()
        {
            return View(db.Kategori.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Kategori t, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ds = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/KategoriResimleri/");
                file.SaveAs(p + file.FileName);
                using (db)
                {
                    t.KategoriResim = file.FileName;
                    db.Kategori.Add(t);
                    db.SaveChanges();
                }
            }
            else
            {
                return Content("resim yükle");
            }
            return RedirectToAction("Index");
        }

        //update
        public ActionResult Edit(int id = 0)
        {
            return View(db.Kategori.Find(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Kategori t, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string sd = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/KategoriResimleri/");
                file.SaveAs(p + file.FileName);
            }

            using (db)
            {

                t.KategoriResim = file.FileName;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            return View(db.Kategori.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Kategori movie = db.Kategori.Find(id);
            db.Kategori.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


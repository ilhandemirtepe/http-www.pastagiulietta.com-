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
    public class SertifikaCRUDController : BaseController
    {
        PastaDBEntities db = new PastaDBEntities();
        public ActionResult LogOut()
        {

            return RedirectToAction("Index", "Login");

        }
        public ActionResult Index()
        {
            return View(db.Sertifikalar.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sertifikalar t, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ds = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/SertifikaResimleri/");
                file.SaveAs(p + file.FileName);
                using (db)
                {
                    t.SertifikaResim= file.FileName;
                    db.Sertifikalar.Add(t);
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
            return View(db.Sertifikalar.Find(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Sertifikalar t, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string sd = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/SertifikaResimleri/");
                file.SaveAs(p + file.FileName);
            }

            using (db)
            {

                t.SertifikaResim = file.FileName;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            return View(db.Sertifikalar.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Sertifikalar movie = db.Sertifikalar.Find(id);
            db.Sertifikalar.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
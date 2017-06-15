
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
    public class TarifCRUDController : BaseController
    {
        // GET: TarifCRUD
        PastaDBEntities db = new PastaDBEntities();
        public ActionResult LogOut()
        {

            return RedirectToAction("Index", "Login");

        }
        public ActionResult Index()
        {
            return View(db.Tarifim.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tarifim t, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ds = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/TarifResimleri/");
                file.SaveAs(p + file.FileName);
                using (db)
                {
                    t.TarifResim = file.FileName;
                    db.Tarifim.Add(t);
                    db.SaveChanges();
                }
            }
            else
            {
                return Content("resim yükle");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            return View(db.Tarifim.Find(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Tarifim t, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string sd = file.FileName.Substring(file.FileName.Length - 3);
                string p = string.Empty;
                p = Server.MapPath("~/Content/TarifResimleri/");
                file.SaveAs(p + file.FileName);
            }

            using (db)
            {

                t.TarifResim = file.FileName;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            return View(db.Tarifim.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Tarifim movie = db.Tarifim.Find(id);
            db.Tarifim.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using PastaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastaMVC.Controllers
{
    public class AdminCRUDController : Controller
    {
        // GET: AdminCRUD
     
        PastaDBEntities db = new PastaDBEntities();
        public ActionResult LogOut()
        {

            return RedirectToAction("Index", "Login");

        }
        public ActionResult Index()
        {
            return View(db.Admin.ToList());
        }
        public ActionResult Delete(int id = 0)
        {
            return View(db.Admin.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Admin movie = db.Admin.Find(id);
            db.Admin.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin UyeBilgi)
        {
            db.Admin.Add(UyeBilgi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
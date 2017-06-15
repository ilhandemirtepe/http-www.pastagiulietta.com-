using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PastaMVC.Models;
namespace PastaMVC.Controllers
{
    public class iletisimCRUDController : Controller
    {
        // GET: iletisimCRUD
        PastaDBEntities db = new PastaDBEntities();
        public ActionResult LogOut()
        {

            return RedirectToAction("Index", "Login");

        }
       
        public ActionResult Index()
        {
            return View(db.Contact.ToList());
        }
        public ActionResult Delete(int id = 0)
        {
            return View(db.Contact.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Contact movie = db.Contact.Find(id);
            db.Contact.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PastaMVC.Models;
namespace PastaMVC.Controllers
{
    public class iletisimController : Controller
    {
        //
        // GET: /iletisim/
        PastaDBEntities db = new PastaDBEntities();
       
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult Create()
        {
            return View();
        }
         [HttpPost]
         public ActionResult Create(Contact UyeBilgi)
         {

             ModelState.Clear();
             db.Contact.Add(UyeBilgi);
             db.SaveChanges();
             return View();
         }
 
        



    }
}

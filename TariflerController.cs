using PastaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastaMVC.Controllers
{
    public class TariflerController : Controller
    {
        //
        // GET: /Tarifler/
        PastaDBEntities db = new PastaDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetayaGit(int id = 0)
        {
            return View(db.Tarifim.Find(id));
        }

    }
}

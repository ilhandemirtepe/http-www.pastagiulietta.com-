using PastaMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastaMVC.Controllers
{
    public class UrunlerController : Controller
    {
        private InterfaceKategoriRepository rep = new KategoriRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KategoriDetay(int id)
        {
            var kategori = rep.find(id);
            ViewBag.MyUrun = kategori.Product.ToList();

            return View("KategoriDetay");
        }

    }
}

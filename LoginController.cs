using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PastaMVC.Models;
namespace PastaMVC.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string username = form["ka"].Trim();
            string password = form["pa"].Trim();

            using (PastaDBEntities db = new PastaDBEntities())
            {
                var vv = db.Admin.Where(a => a.AdminUserName.Equals(username) && a.AdminPassWord.Equals(password)).FirstOrDefault();
                if (vv != null)
                {
                    Session["Adminid"] = vv.Adminid.ToString();
                    Session["AdminName"] = vv.AdminName.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Message"] = "kullanıcı adı yada şifre yanlış";

                }
            }
            return View("Index");
        }
        public ActionResult LogOut()
        {

            return RedirectToAction("Index", "Login");

        }
        

        

       

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastaMVC.Utils
{
    public class BaseController : System.Web.Mvc.Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            if (Session["Adminid"] == null)
            {
                filtercontext.Result = new RedirectResult("~/Login");
                return;
            }
            base.OnActionExecuting(filtercontext);
        }
    }
}
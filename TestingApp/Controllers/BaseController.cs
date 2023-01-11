using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingApp.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session["user_info"] == null) //check if user is already login or not
            {
                TempData["error"] = "Please login to continue"; 
                filterContext.Result = RedirectToAction("LoginPage", "Login", new { area = "" });
            }
            else 
            {
                ViewBag.CurrentController = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            }
        }
    }
}
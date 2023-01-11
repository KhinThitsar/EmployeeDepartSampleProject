using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestingApp.Models;
namespace TestingApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LoginTest(string data)
        {
            LoginModel loginUser = new LoginModel();
            LoginModel[] userData = JsonConvert.DeserializeObject<List<LoginModel>>(data).ToArray();
            loginUser = userData[0];
            testEntities test = new testEntities();
            var employees = test.Employees.Where(x => x.Employee_Name == loginUser.UserName && x.Password == loginUser.Password); ;
            string returnMsg = string.Empty;
            var item = employees.FirstOrDefault();
            if (item !=null)
            {
                Session["user_info"] = loginUser;
                returnMsg = "Success";
            }
            else
            {
                ViewBag.Error = "User Name and Password not matched";
                returnMsg = "Fail";
            }

            return Json(new { returnMsg }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["user_info"] = null;
            return RedirectToAction("LoginPage", "Login", new { area = "" });
        }

    }
}
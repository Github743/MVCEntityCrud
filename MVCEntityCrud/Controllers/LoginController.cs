using MVCCrud.Model;
using MVCEntityCrud.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCEntityCrud.Controllers
{
    public class LoginController : Controller
    {
        private readonly Login_DAL Login_DAL = new Login_DAL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {

                // Sample User Authentication (Replace with Database logic)
                if (Login_DAL.ValidateLogin(model))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Home"); // Redirect to Home Page
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
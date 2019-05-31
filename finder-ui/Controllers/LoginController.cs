using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;
using finder_ui.UserProfileServiceReference;

namespace finder_ui.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel
            {
                Controller = TempData["ReturnToController"]?.ToString() ?? "Service",
                Action = TempData["ReturnToAction"]?.ToString() ?? "MyServices",
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            string loginEmail;
            User user;
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                user = client.GetUserByUserNameOrEmail(vm.username);
                loginEmail = user?.Email;
            }

            using (var client = new UserLoginServiceReference.LoginServiceClient())
            {
                if (!client.UserLogin(loginEmail, vm?.userPassword ?? ""))
                {
                    Session["AuthorizedAsUser"] = "false";
                    Session["UserID"] = null;
                    ModelState.AddModelError("", "inloggningen misslyckades.");
                    return View(vm);
                }
            }

            Session["AuthorizedAsUser"] = "true";
            Session["UserID"] = user.Id;
            return RedirectToAction(vm.Action, vm.Controller);
        }
    }
}

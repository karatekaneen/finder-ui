using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;

namespace finder_ui.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel
            {
                Controller = TempData["ReturnToController"].ToString(),
                Action = TempData["ReturnToAction"].ToString(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            using (var client = new UserLoginServiceReference.LoginServiceClient())
            {
                if (client.UserLogin(vm.username, vm.userPassword))
                {
                    Session["AuthorizedAsUser"] = "true";
                    Session["UserID"] = client.GetUserId(vm.username);
                    return RedirectToAction(vm.Action, vm.Controller);
                }
                else
                {
                    Session["AuthorizedAsUser"] = "false";
                    Session["UserID"] = null;
                }
            }
            return View(vm);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;
using finder_ui.SessionHandler;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    public class NavbarController : Controller
    {

        public PartialViewResult NavbarPartial()
        {
            int.TryParse(Session["UserId"]?.ToString() ?? "", out int userid);
            var viewModel = new NavbarPartialViewModel
            {
                LoggedIn = (Session["AuthorizedAsUser"]?.ToString()) == "true",
                UserId = userid,
                Username = "Error!",
                UserPicture = "/Content/Images/fnd-user2.png",
            };
            if (viewModel.LoggedIn && userid > 0)
            {
                using (var client = new UserProfileServiceReference.UserProfileServiceClient())
                {
                    if (client.UserIdExistsInProfile(userid))
                    {
                        viewModel.Username = client.GetUserByUserId(userid).Username;
                    }
                }
            }
            return PartialView(viewModel);
        }

    }
}
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace finder_ui.SessionHandler
{
    public class CustomAuthorization
    {
        
    public class CustomAuthorizationAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                //return false;
                if (httpContext.Session["AuthorizedAsUser"] == null || httpContext.Session["AuthorizedAsUser"].ToString() != "true")
                {
                    return false;
                }
                return true;

            }

            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Controller.TempData["ReturnToController"] = filterContext.RequestContext.RouteData.GetRequiredString("controller");
                filterContext.Controller.TempData["ReturnToAction"] = filterContext.RequestContext.RouteData.GetRequiredString("action");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login" }));
            }

        }
    }
}

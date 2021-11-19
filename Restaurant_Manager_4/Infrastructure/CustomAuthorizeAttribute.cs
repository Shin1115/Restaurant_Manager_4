using System.Web;
using System.Web.Mvc;
using System;

namespace Restaurant_Manager_4.Infrastructure
{
    /// <summary>
    /// Annotation này được gắn trên controller hoặc action nhằm yêu cầu xác thực trước khi truy cập
    /// vào controller hoặc action đó.
    /// </summary>
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return ((CurrentUser != null && !CurrentUser.IsInRole(Roles)) || CurrentUser == null) ? false : true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (CurrentUser == null)
            {
                routeData = new RedirectToRouteResult
                (
                    new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller = "Account",
                        action = "Login",
                        area = "",
                        ReturnUrl = filterContext.HttpContext.Request.Url?.GetComponents(
                                            UriComponents.PathAndQuery, UriFormat.SafeUnescaped)
                    })
                );
            }
            else
            {
                routeData = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                 (new
                 {
                     controller = "Error",
                     action = "AccessDenied"
                 }
                 ));
            }

            filterContext.Result = routeData;
        }
    }
}
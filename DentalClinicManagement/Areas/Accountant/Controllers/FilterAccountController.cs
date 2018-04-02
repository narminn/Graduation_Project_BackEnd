using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentalClinicManagement.Areas.Accountant.Controllers
{
    public class FilterAccount : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
    {
        if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
        {
            // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
            return;
        }

        // Check for authorization
        if (HttpContext.Current.Session["AccountEmail"] == null)
        {
            filterContext.Result = new RedirectResult("/Accountant/Home/Login");
        }
    }
}
}
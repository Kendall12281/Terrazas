using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Security.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (User)HttpContext.Current.Session["User"];

            if (oUser != null)
            {
            //Admin
            if (filterContext.Controller is ResidentController == true && oUser.IdRol != 1) { filterContext.HttpContext.Response.Redirect("~/Home/"); }
            if (filterContext.Controller is PlanController == true && oUser.IdRol != 1) { filterContext.HttpContext.Response.Redirect("~/Home/"); }
            if (filterContext.Controller is SocialAreaController == true && oUser.IdRol != 1) { filterContext.HttpContext.Response.Redirect("~/Home/"); }


            //Regular User

            }else {
                filterContext.HttpContext.Response.Redirect("~/Login/");
            }


            base.OnActionExecuting(filterContext);
        }
    }
}
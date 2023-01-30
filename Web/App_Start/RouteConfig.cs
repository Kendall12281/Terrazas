﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

                    routes.MapRoute(
            name: "Resident",
            url: "{controller}/{action}/{id}",
            defaults: new
            {
                controller = "Resident",
                action = "Edit",
                id = UrlParameter.Optional
            });
        }
    }
}
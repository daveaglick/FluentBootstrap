using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FluentBootstrap.Tests.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Index", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("Tests", "Tests/{*view}", new { controller = "Tests", action = "Tests" });
        }
    }
}

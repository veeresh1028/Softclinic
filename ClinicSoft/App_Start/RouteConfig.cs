using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClinicSoft
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "CatchAll",
            url: "{area}/{controller}",
            defaults: new { action = "Index" }
        );
            //routes.MapRoute("SpecificRoute", "{action}/{id}", new { controller = "Account", action = "Login", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyDashboard", action = "DashboardIndex", id = UrlParameter.Optional },
                namespaces: new string[] { "ClinicSoft.Controllers" }
            ).DataTokens["area"] = "Dashboard";
        }
    }
}

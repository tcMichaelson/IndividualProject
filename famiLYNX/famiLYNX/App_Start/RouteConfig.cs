using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace famiLYNX {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Member Profile",
                 url: "{userID}",
                 defaults: new { controller = "Members", Action = "MyProfile" }
                 );

            routes.MapRoute(
                name: "Family Page",
                url: "{userID}/{famName}",
                defaults: new {controller = "Familys", Action="MyFamily"}
            );

            routes.MapRoute(
                name: "Family View",
                url: "Members/Families",
                defaults: new { controller="Familys", Action="Index"}
                );

            routes.MapRoute(
                name: "Member View",
                url: "Members",
                defaults: new { controller = "Members", Action = "Index"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

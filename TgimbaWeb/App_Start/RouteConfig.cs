using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TgimbaRestService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "WebRequest", action = "WelcomePage", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "ControllerAndAction",
                url: "api/{controller}/{action}"
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "WebBucketList", action = "Desktop", id = UrlParameter.Optional }
            //);

            //WebBucketList/Desktop
        }
    }
}

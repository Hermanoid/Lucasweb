﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lucasweb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "CodeCraft",
            //    url: "CodeCraft/{action}/{WeekId}/{htmlFile}",
            //    defaults: new { controller = "Codecraft", action = "Index" }
            //    );
            routes.MapRoute(
                name: "Manage",
                url: "Manage/{action}/{table}/{id}",
                defaults: new { controller = "Manage", action = "Index", table = UrlParameter.Optional, id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}

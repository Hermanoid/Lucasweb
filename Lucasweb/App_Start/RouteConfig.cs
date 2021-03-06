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


            routes.MapRoute(
                name: "UserName",
                url: "{controller}/{action}/{UserName}",
                defaults: new { controller = "Home", action = "Index", UserName = UrlParameter.Optional },
                namespaces: new string[] { "Lucasweb.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new string[] { "Lucasweb.Controllers" }
            );


        }
    }
}

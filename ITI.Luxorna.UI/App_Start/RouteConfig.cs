using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ITI.Luxorna.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{pageIndex}/{pageSize}/{ResturantID}/{name}",
                defaults: new { controller = "Home", action = "Index", pageIndex = UrlParameter.Optional,
                    ResturantID = UrlParameter.Optional,
                    pageSize = UrlParameter.Optional,
                    name = UrlParameter.Optional


                }
            );
            routes.MapRoute(
                name: "Default3",
                url: "{controller}/{action}/{startDate}/{endDate}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    startDate = UrlParameter.Optional,
                    endDate = UrlParameter.Optional,
                   


                }
            );
        }
    }
}

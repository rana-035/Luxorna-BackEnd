﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ITI.Luxorna.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["Counter"] = 0;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
            int counter
                = int.Parse(Application["Counter"].ToString());
            counter++;
            Application["Counter"] = counter;
            Session["Counter"] = counter;


        }

        protected void Application_BeginRequest()
        {
            if(Request.Headers.AllKeys.Contains
                ("Origin") && Request.HttpMethod=="OPTIONS")
                Response.Flush();
        }
    }
}

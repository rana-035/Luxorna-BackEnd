using Autofac;
using Autofac.Integration.WebApi;
using ITI.Luxorna.Repositories;
using ITI.Luxorna.Repositories.Context;
using ITI.Luxorna.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;

namespace ITI.Luxorna.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired().InstancePerRequest();

            builder.RegisterType<EntitiesContext>()
               .InstancePerRequest();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .InstancePerRequest();
            builder.RegisterType<UnitOfWork>()
                .InstancePerRequest();
            builder.RegisterAssemblyTypes
                (
                typeof(AdminService).Assembly
                ).Where(i => i.Name.EndsWith("Service"))
                .InstancePerRequest();
            builder.RegisterType<SecurityHelper>()
                .InstancePerRequest();

            IContainer c = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(c);


        }
    }
}

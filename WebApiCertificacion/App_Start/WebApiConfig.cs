using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiCertificacion
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            config.EnableCors();

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetServiceById",
                routeTemplate: "api/{controller}/GetOne/{id}",
                defaults: new { controller = "ServiciosController", action = "GetOne", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetByBussiness",
                routeTemplate: "api/{controller}/GetByBussiness/{id}",
                defaults: new { controller = "ServiciosController", action = "GetByBussiness", id = RouteParameter.Optional }
            );
        }
    }
}

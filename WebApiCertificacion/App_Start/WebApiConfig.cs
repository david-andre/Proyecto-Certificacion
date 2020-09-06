using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiCertificacion.Models;

namespace WebApiCertificacion
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler());

            // Rutas de API web

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
            config.Routes.MapHttpRoute(
                name: "GetPedidoById",
                routeTemplate: "api/{controller}/GetOne/{id}",
                defaults: new { controller = "PedidosController", action = "GetOne", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetByClient",
                routeTemplate: "api/{controller}/GetByClient/{id}",
                defaults: new { controller = "PedidosController", action = "GetByClient", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetDetalleById",
                routeTemplate: "api/{controller}/GetOne/{id}",
                defaults: new { controller = "DetallePedidoController", action = "GetOne", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetByPedido",
                routeTemplate: "api/{controller}/GetByPedido/{id}",
                defaults: new { controller = "DetallePedidoController", action = "GetByPedido", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetClientByUser",
                routeTemplate: "api/{controller}/GetByUser/{id}",
                defaults: new { controller = "ClientesController", action = "GetByUser", id = RouteParameter.Optional }
            );

        }
    }
}

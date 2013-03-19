using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;

namespace PublicationsService
{
    public class WebApiConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ProductRelated",
                routeTemplate: "ProductRelatedComponents/{id}",
                defaults: new { controller = "Components", action = "ProductRelated", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GeneralComponent",
                routeTemplate: "GeneralComponents/{id}",
                defaults: new { controller = "Components", action = "GeneralComponent", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional },
                constraints: new
                {
                    httpMethod = new HttpMethodConstraint(
                         new HttpMethod[] { 
                            HttpMethod.Post, 
                            HttpMethod.Put, 
                            HttpMethod.Delete
                        })
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiGet",
                routeTemplate: "{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional, action = "GET" }
            );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Cepheus
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Image",
                routeTemplate: "{controller}/{id}/Image",
                defaults: new { id = RouteParameter.Optional, action = "Image" }
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
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}

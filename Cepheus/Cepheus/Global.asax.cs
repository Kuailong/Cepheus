using Cepheus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Cepheus.Infrastructure;
using Cepheus.Entities;

namespace Cepheus
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;

            //try
            //{
            //    Database.SetInitializer(new DropCreateDatabaseAlways<CepheusContext>());
            //    var context = new CepheusContext();
            //    var repository = new Repository<Developer>(context);
            //    var develop = new Developer()
            //        {
            //            Name = "Valve Corporation",
            //            Description = "ValveRules"
            //        };

            //    repository.Add(develop);
            //    context.SaveChanges();
            //    context.Dispose();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
    }
}
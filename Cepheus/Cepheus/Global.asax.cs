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
            //    var repository = new Repository<Game>(context);
            //    var develop = new Game()
            //    {
            //        Developer = new Developer()
            //        {
            //            Name = "Valve Corporation",
            //            Description = "ValeRules"
            //        },
            //        Name = "CS 1.6",
            //        ImagePath = "null",
            //        GameTypes = new List<GameType>()
            //        {
            //            new GameType() { Type = "Multiplayer", Description = "mutli" },
            //            new GameType() { Type = "SinglePlayer", Description = "single" }
            //        }
            //    };

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
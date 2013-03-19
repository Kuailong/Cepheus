using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Procad.DataAccess.Interfaces;
using PublicationsService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization.Formatters;
using Promob.Entities;
using Procad.DataAccess.RepositoryBase;

namespace PublicationsService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.RegisterRoutes(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            //try
            //{
            //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PromobPublicationsEntities>());
            //    var context = new PromobPublicationsEntities();
            //    var repository = new Repository<Updates>(context);
            //    var up = new Updates() { AccountId = 1, ComponentId = 2, LibraryId = "2", PublicationVersion = "3.34.5", SerialNumber = "234123", UpdateDate = DateTime.Now };

            //    repository.Add(up);
            //    context.Save();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("DB não criado:\n" + ex.ToString());
            //}
        }
    }
}
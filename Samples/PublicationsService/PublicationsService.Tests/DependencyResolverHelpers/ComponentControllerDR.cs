using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dependencies;
using Promob.Entities;
using Procad.DataAccess.Interfaces;
using PublicationsService.Controllers;
using System.Web.Http;
using PublicationsService.Models;
using Procad.DataAccess.RepositoryBase;

namespace PublicationsService.Tests.DependencyResolversHelpers
{
    public class ComponentControllerDR : IDependencyResolver
    {
        IRepository<Component> _repository;
        PromobPublicationsEntities _context;

        public ComponentControllerDR(IRepository<Component> repository, PromobPublicationsEntities context)
        {
            this._repository = repository;
            this._context = context;
        }

        public IDependencyScope BeginScope()
        {
            // This example does not support child scopes, so we simply return 'this'.
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(ComponentsController))
                return new ComponentsController();
            else
                return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}

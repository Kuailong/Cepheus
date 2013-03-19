using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Procad.DataAccess.Interfaces;
using Promob.Entities;
using PublicationsService.Models;
using Procad.DataAccess.RepositoryBase;
using System.Net.Http;
using System.Net;
using PublicationsService.Infrastructure;

namespace PublicationsService.Controllers
{
    public class PublicationsPackageController : ApiController
    {
        readonly IUnitOfWork _context;

        #region Constructor 
        
        public PublicationsPackageController()
        {
            this._context = new PromobPublicationsEntities();
        }

        /*necessário para testes*/
        public PublicationsPackageController(PromobPublicationsEntities context)
        {
            this._context = context;
        }

        #endregion

        #region Actions

        [Queryable]
        public IQueryable<PublicationPackageItem> Get(int productId = 0, int accountId = 0, string serialNumber = null)
        {
            var publicationPackages = new PublicationPackagesRepository(this._context)
                .GetPublicationPackagesByCriterias(productId, accountId, serialNumber);

            if (publicationPackages == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return publicationPackages.AsQueryable();
        }

        #endregion

        #region Override Methods

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }

	    #endregion
    }
}

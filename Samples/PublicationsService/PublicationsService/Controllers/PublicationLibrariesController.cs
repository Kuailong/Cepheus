using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Procad.DataAccess.Interfaces;
using Procad.DataAccess.RepositoryBase;
using Promob.Entities;
using PublicationsService.Models;

namespace PublicationsService.Controllers
{
    public class PublicationLibrariesController : ApiController
    {
        readonly IRepository<PublicationLibrary> _repository;
        readonly IUnitOfWork _context;

        #region Constructor 
        
        public PublicationLibrariesController()
        {
            this._context = new PromobPublicationsEntities(false);
            this._repository = new Repository<PublicationLibrary>(this._context);
        }

        /*necessário para testes*/
        public PublicationLibrariesController(IRepository<PublicationLibrary> repository, PromobPublicationsEntities context)
        {
            this._repository = repository;
            this._context = context;
        }

        #endregion
        [Queryable]
        public IQueryable<PublicationLibrary> Get()
        {
            var result = this._repository.Get();
            if(result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        public PublicationLibrary Get(int id)
        {
            var result = this._repository.Get(e => e.PublicationLibraryId == id);
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        public HttpResponseMessage Post(PublicationLibrary value)
        {
            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<PublicationLibrary>(HttpStatusCode.Created, value);

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.PublicationLibraryId == id).SingleOrDefault();

            this._repository.Remove(value);
            this._context.Save();

            var response = Request.CreateResponse<PublicationLibrary>(HttpStatusCode.OK, value);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}

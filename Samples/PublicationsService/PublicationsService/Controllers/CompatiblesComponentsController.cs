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
    public class CompatiblesComponentsController : ApiController
    {
        readonly IRepository<PublicationsComponentsCompatibilities> _repository;
        readonly IUnitOfWork _context;

        #region Constructor 
        
        public CompatiblesComponentsController()
        {
            this._context = new PromobPublicationsEntities(false);
            this._repository = new Repository<PublicationsComponentsCompatibilities>(this._context);
        }

        #endregion

        [HttpGet]
        [Queryable]
        public IQueryable<PublicationsComponentsCompatibilities> Get()
        {
            var result = this._repository.Get(e => e.Component, e => e.Publication);

            if (result == null || result.Count() == 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        public PublicationsComponentsCompatibilities Get(int id)
        {
            var result = this._repository.Get(e => e.CompatibilityId == id, e => e.Component, e => e.Publication)
                  .FirstOrDefault();

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpPost]
        public HttpResponseMessage Post(PublicationsComponentsCompatibilities value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<PublicationsComponentsCompatibilities>(HttpStatusCode.Created, value);

            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, PublicationsComponentsCompatibilities value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            value.CompatibilityId = id;
            this._repository.Update<PublicationsComponentsCompatibilities>(value);
            this._context.Save();

            var response = Request.CreateResponse<PublicationsComponentsCompatibilities>(HttpStatusCode.OK, value);

            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.CompatibilityId == id).SingleOrDefault();

            this._repository.Remove(value);
            this._context.Save();

            var response = Request.CreateResponse<PublicationsComponentsCompatibilities>(HttpStatusCode.OK, value);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using Procad.DataAccess.Interfaces;
using Procad.DataAccess.RepositoryBase;
using Promob.Entities;
using PublicationsService.Models;

namespace PublicationsService.Controllers
{
    public class UpdatesController : ApiController
    {
        readonly IRepository<Updates> _repository;
        readonly IUnitOfWork _context;

        #region Constructor 
        
        public UpdatesController()
        {
            this._context = new PromobPublicationsEntities(false);
            this._repository = new Repository<Updates>(this._context);
        }

        #endregion
        [Queryable]
        [HttpGet]
        public IQueryable<Updates> Get()
        {
            var result = this._repository.Get();
            if(result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        public Updates Get(int id)
        {
            var result = this._repository.Get(e => e.Id == id);
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        [HttpPost]
        public HttpResponseMessage Post(Updates value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<Updates>(HttpStatusCode.Created, value);

            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Updates value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            value.Id = id;
            this._repository.Update<Updates>(value);
            this._context.Save();

            var response = Request.CreateResponse<Updates>(HttpStatusCode.OK, value);

            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.Id == id).SingleOrDefault();

            this._repository.Remove(value);
            this._context.Save();

            var response = Request.CreateResponse<Updates>(HttpStatusCode.OK, value);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cepheus.Entities;
using Cepheus.Infrastructure;
using Cepheus.Models;

namespace Cepheus.Controllers
{
    public class GameTypesController : ApiController
    {
        #region Private Properties

        readonly Repository<GameType> _repository;
        readonly DbContext _context; 

        #endregion

        #region Constructor

        public GameTypesController()
        {
            this._context = new CepheusContext();
            this._repository = new Repository<GameType>(this._context);
        }

        #endregion

        #region Actions

        [HttpGet]
        public IQueryable<GameType> Get()
        {
            var result = this._repository.Get();

            if (result == null || result.Count() == 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        public GameType Get(int id)
        {
            var result = this._repository.Get(e => e.GameTypeId == id)
                  .FirstOrDefault();

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        [ActionName("Search")]
        public IQueryable<GameType> Search(string value)
        {
            var result = this._repository.Get(e => e.Type.Contains(value));

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpPost]
        public HttpResponseMessage Post(GameType value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Add(value);
            this._context.SaveChanges();

            return Request.CreateResponse<GameType>(HttpStatusCode.Created, value);
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, GameType value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            value.GameTypeId = id;
            this._repository.Update<GameType>(value);
            this._context.SaveChanges();

            return Request.CreateResponse<GameType>(HttpStatusCode.OK, value);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.GameTypeId == id).SingleOrDefault();

            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Remove(value);
            this._context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion

        #region Override

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Cepheus.Entities;
using Cepheus.Infrastructure;
using Cepheus.Models;

namespace Cepheus.Controllers
{
    public class GamesController : ApiController
    {
        #region Private Properties

        readonly Repository<Game> _repository;
        readonly DbContext _context; 

        #endregion

        #region Constructor

        public GamesController()
        {
            this._context = new CepheusContext(false);
            this._repository = new Repository<Game>(this._context);
        }

        #endregion

        #region Actions

        [HttpGet]
        public IQueryable<Game> Get()
        {
            var result = this._repository.Get(e => e.Developer, e => e.GameTypes);

            if (result == null || result.Count() == 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        public Game Get(int id)
        {
            var result = this._repository.Get(e => e.GameId == id, e => e.Developer, e => e.GameTypes)
                  .FirstOrDefault();

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        [ActionName("Search")]
        public IQueryable<Game> Search(string value)
        {
            var result = this._repository.Get(e => e.Name.Contains(value), e => e.GameTypes, e => e.Developer);

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        public HttpResponseMessage Image(int id)
        {
            var game = this._repository.Get(e => e.GameId == id)
                .FirstOrDefault();
            if (game == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var path = string.Format(@"C:\Temp\{0}_{1}.jpg", id, game.Name);
            var stream = new FileStream(path, FileMode.Open);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "test.jpg";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = stream.Length;

            return response;
        }

        [HttpPost]
        public HttpResponseMessage Post(Game value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Add(value);
            this._context.SaveChanges();

            return Request.CreateResponse<Game>(HttpStatusCode.Created, value);
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Game value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            value.GameId = id;
            this._repository.Update<Game>(value);
            this._context.SaveChanges();

            return Request.CreateResponse<Game>(HttpStatusCode.OK, value);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.GameId == id).SingleOrDefault();

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

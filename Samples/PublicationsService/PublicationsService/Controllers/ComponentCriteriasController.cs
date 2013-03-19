using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Procad.DataAccess.Interfaces;
using Procad.DataAccess.RepositoryBase;
using Promob.Entities;
using PublicationsService.Models;

namespace PublicationsService.Controllers
{
    public class ComponentCriteriasController : ApiController
    {
        readonly IRepository<ComponentCriteria> _repository;
        readonly IUnitOfWork _context;

        #region Constructor 
        
        public ComponentCriteriasController()
        {
            this._context = new PromobPublicationsEntities(false);
            this._repository = new Repository<ComponentCriteria>(this._context);
        }

        /*necessário para testes*/
        public ComponentCriteriasController(IRepository<ComponentCriteria> repository, PromobPublicationsEntities context)
        {
            this._repository = repository;
            this._context = context;
        }

        #endregion
        [Queryable]
        public IQueryable<ComponentCriteria> Get()
        {
            var result = this._repository.Get();
            if(result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        public ComponentCriteria Get(int id)
        {
            var result = this._repository.Get(e => e.ComponentCriteriaId == id);
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        public HttpResponseMessage Post(ComponentCriteria value)
        {
            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<ComponentCriteria>(HttpStatusCode.Created, value);

            return response;
        }

        public HttpResponseMessage Put(int id, ComponentCriteria value)
        {
            value.AccountId = id;
            this._repository.Update<ComponentCriteria>(value);
            this._context.Save();

            var response = Request.CreateResponse<ComponentCriteria>(HttpStatusCode.OK, value);

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.ComponentCriteriaId == id).SingleOrDefault();

            this._repository.Remove(value);
            this._context.Save();

            var response = Request.CreateResponse<ComponentCriteria>(HttpStatusCode.OK, value);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Procad.DataAccess.Interfaces;
using Procad.DataAccess.RepositoryBase;
using Promob.Entities;
using PublicationsService.Infrastructure;
using PublicationsService.Models;

namespace PublicationsService.Controllers
{
    public class PublicationsController : ApiController
    {
        readonly IRepository<Publication> _repository;
        readonly IRepository<PublicationsComponentsCompatibilities> _publicationsCompatibilitiesRepository;
        readonly IUnitOfWork _context;
        readonly ComponentsCriteriaRepository _componentCriteriasRepository;

        #region Constructor 
        
        public PublicationsController()
        {
            this._context = new PromobPublicationsEntities(false);
            this._repository = new Repository<Publication>(this._context);
            this._publicationsCompatibilitiesRepository = new Repository<PublicationsComponentsCompatibilities>(this._context);
            this._componentCriteriasRepository = new ComponentsCriteriaRepository(this._context);
        }

        #endregion

        #region Actions
        [Queryable]
        public IQueryable<Publication> Get()
        {
            var result = this._repository.Get();

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.AsQueryable();
        }

        public Publication Get(int id)
        {
            var result = this._repository.Get(e => e.PublicationId == id);
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        [HttpGet]
        [Queryable]
        [ActionName("CompatiblesComponents")]
        public IQueryable<PublicationsComponentsCompatibilities> GetCompatibleComponents(int id)
        {
            var result = this._publicationsCompatibilitiesRepository.Get(c => c.PublicationId == id);

            return result;
        }

        [HttpGet]
        [Queryable]
        [ActionName("ComponentCriterias")]
        public IQueryable<ComponentCriteria> GetComponentCriterias(int id)
        {
            var result = this._componentCriteriasRepository.GetComponentsCriterias(id);

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.AsQueryable();
        }

        public HttpResponseMessage Post(Publication value)
        {
            this._repository.Add(value);
            this._context.Save();

            return this.Request.CreateResponse<Publication>(HttpStatusCode.Created, value);
        }

        public HttpResponseMessage Put(int id, Publication value)
        {
            value.PublicationId = id;
            this._repository.Update<Publication>(value);
            this._context.Save();

            var response = Request.CreateResponse<Publication>(HttpStatusCode.OK, value);

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.PublicationId == id).SingleOrDefault();

            this._repository.Remove(value);
            this._context.Save();

            var response = Request.CreateResponse<Publication>(HttpStatusCode.OK, value);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }

        #endregion
    }
}

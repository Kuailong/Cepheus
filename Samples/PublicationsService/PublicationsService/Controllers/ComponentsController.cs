using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Promob.Entities;
using Procad.DataAccess.Interfaces;
using PublicationsService.Models;
using Procad.DataAccess.RepositoryBase;

namespace PublicationsService.Controllers
{
    public class ComponentsController : ApiController
    {
        readonly IRepository<Component> _repository;
        readonly IRepository<ProductRelatedComponent> _repositoryProductRelated;
        readonly IUnitOfWork _context;
        private Repository<GeneralComponent> _repositoryGeneralComponent;

        #region Constructor 
        
        public ComponentsController()
        {
            this._context = new PromobPublicationsEntities(false);
            this._repository = new Repository<Component>(this._context);
            this._repositoryProductRelated = new Repository<ProductRelatedComponent>(this._context);
            this._repositoryGeneralComponent = new Repository<GeneralComponent>(this._context);
        }

        /*necessário para testes*/
        public ComponentsController(
            IRepository<Component> repository,
            PromobPublicationsEntities context)
        {
            this._repository = repository;
            this._context = context;
        }

        #endregion

        #region Actions

        [Queryable]
        [HttpGet]
        public IQueryable<Component> Get()
        {
            var result = this._repository.Get();
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.AsQueryable();
        }

        [HttpGet]
        public Component Get(int id)
        {
            var result = this._repository.Get(c => c.ComponentId == id);

            if (result == null || result.Count() <= 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        [Queryable]
        [HttpGet]
        [ActionName("ProductRelated")]
        public IQueryable<ProductRelatedComponent> GetProductRelated()
        {
            var result = this._repositoryProductRelated.Get();
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("ProductRelated")]
        public ProductRelatedComponent GetProductRelated(int id)
        {
            var result = this._repositoryProductRelated.Get(e => e.ComponentId == id);

            if (result == null || result.Count() <= 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        [HttpGet]
        [ActionName("ProductRelated")]
        public ProductRelatedComponent GetProductRelatedByProductID(int productID)
        {
            var result = this._repositoryProductRelated.Get(e => e.ProductId == productID);

            if (result == null || result.Count() <= 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        [Queryable]
        [HttpGet]
        [ActionName("GeneralComponent")]
        public IQueryable<GeneralComponent> GetGeneralComponent()
        {
            var result = this._repositoryGeneralComponent.Get();
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.AsQueryable();
        }

        [HttpGet]
        [ActionName("GeneralComponent")]
        public GeneralComponent GetGeneralComponent(int id)
        {
            var result = this._repositoryGeneralComponent.Get(e => e.ComponentId == id);

            if (result == null || result.Count() <= 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        [HttpGet]
        [ActionName("ComponentType")]
        public ComponentType GetGeneralComponentType(int id)
        {
            var result = this._repository.Get(e => e.ComponentId == id).Select(c => c.ComponentType);

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.First();
        }

        [Queryable]
        [HttpGet]
        [ActionName("Publications")]
        public IQueryable<Publication> GetPublications(int id)
        {
            var result = this._repository
                .Get(e => e.ComponentId == id)
                .Select(c => c.Publications)
                .First()
                .AsQueryable();

            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        [ActionName("Count")]
        public int GetCount(int id)
        {
            return this._repository
                .Get(e => e.ComponentId == id)
                .Select(c => c.Publications)
                .First()
                .Count();
        }

        [Queryable]
        [HttpGet]
        [ActionName("PublicationsActive")]
        public IQueryable<Publication> GetPublicationsActive(int id)
        {
            var result = this._repository
                .Get(e => e.ComponentId == id)
                .Select(c => c.Publications
                    .Where(p => p.Active)
                    .Select(p => p))
                .First()
                .AsQueryable();

            if (result == null || result.Count() <= 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpPost]
        [ActionName("GeneralComponent")]
        public HttpResponseMessage Post(GeneralComponent value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<GeneralComponent>(HttpStatusCode.Created, value);

            return response;
        }

        [HttpPut]
        [ActionName("GeneralComponent")]
        public HttpResponseMessage Put(int id, GeneralComponent value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            value.ComponentId = id;
            this._repository.Update<GeneralComponent>(value);
            this._context.Save();

            var response = Request.CreateResponse<GeneralComponent>(HttpStatusCode.OK, value);

            return response;
        }

        [HttpPost]
        [ActionName("ProductRelated")]
        public HttpResponseMessage Post(ProductRelatedComponent value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<ProductRelatedComponent>(HttpStatusCode.Created, value);

            return response;
        }

        [HttpPut]
        [ActionName("ProductRelated")]
        public HttpResponseMessage Put(int id, ProductRelatedComponent value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            value.ComponentId = id;
            this._repository.Update<ProductRelatedComponent>(value);
            this._context.Save();

            var response = Request.CreateResponse<ProductRelatedComponent>(HttpStatusCode.OK, value);

            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.ComponentId == id).SingleOrDefault();

            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Remove(value);

            this._context.Save();

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}

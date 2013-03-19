using System.Linq;
using System.Net;
using System.Web.Http;
using Procad.DataAccess.Interfaces;
using Procad.DataAccess.RepositoryBase;
using Promob.Entities;
using PublicationsService.Models;
using System.Net.Http;

namespace PublicationsService.Controllers
{
    public class ComponentTypesController : ApiController
    {
        readonly IRepository<ComponentType> _repository;
        readonly IUnitOfWork _context;

        #region Constructor 
        
        public ComponentTypesController()
        {
            this._context = new PromobPublicationsEntities(false);
            this._repository = new Repository<ComponentType>(this._context);
        }

        /*necessário para testes*/
        public ComponentTypesController(IRepository<ComponentType> repository, PromobPublicationsEntities context)
        {
            this._repository = repository;
            this._context = context;
        }

        #endregion
        [Queryable]
        [HttpGet]
        public IQueryable<ComponentType> Get()
        {
            var result = this._repository.Get();
            if(result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        [HttpGet]
        public ComponentType Get(int id)
        {
            var result = this._repository.Get(e => e.ComponentTypeId == id);
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        [HttpGet]
        [Queryable]
        [ActionName("Components")]
        public IQueryable<Component> GetComponents(int id)
        {
            var result = this._repository.Get(e => e.ComponentTypeId == id).Select(e => e.Components);
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault().AsQueryable();
        }

        [HttpPost]
        public HttpResponseMessage Post(ComponentType value)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<ComponentType>(HttpStatusCode.Created, value);

            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, ComponentType value, string RequiresCompatibility, string Name)
        {
            if (value == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            value.ComponentTypeId = id;
            this._repository.Update<ComponentType>(value);
            this._context.Save();

            var response = Request.CreateResponse<ComponentType>(HttpStatusCode.OK, value);

            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.ComponentTypeId == id).SingleOrDefault();

            this._repository.Remove(value);
            this._context.Save();

            var response = Request.CreateResponse<ComponentType>(HttpStatusCode.OK, value);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}

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
    public class ImportanceLevelsController : ApiController
    {
        readonly IRepository<ImportanceLevel> _repository;
        readonly IUnitOfWork _context;

        #region Constructor 
        
        public ImportanceLevelsController()
        {
            this._context = new PromobPublicationsEntities();
            this._repository = new Repository<ImportanceLevel>(this._context);
        }

        /*necessário para testes*/
        public ImportanceLevelsController(IRepository<ImportanceLevel> repository, PromobPublicationsEntities context)
        {
            this._repository = repository;
            this._context = context;
        }

        #endregion
        [Queryable]
        public IQueryable<ImportanceLevel> Get()
        {
            var result = this._repository.Get();
            if(result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result;
        }

        public ImportanceLevel Get(int id)
        {
            var result = this._repository.Get(e => e.ImportanceLevelId == id);
            if (result == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return result.FirstOrDefault();
        }

        public HttpResponseMessage Post(ImportanceLevel value)
        {
            this._repository.Add(value);
            this._context.Save();

            var response = Request.CreateResponse<ImportanceLevel>(HttpStatusCode.Created, value);

            return response;
        }

        public HttpResponseMessage Put(int id, ImportanceLevel value)
        {
            value.ImportanceLevelId = id;
            this._repository.Update<ImportanceLevel>(value);
            this._context.Save();

            var response = Request.CreateResponse<ImportanceLevel>(HttpStatusCode.OK, value);

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            var value = this._repository.Get(e => e.ImportanceLevelId == id).SingleOrDefault();

            this._repository.Remove(value);
            this._context.Save();

            var response = Request.CreateResponse<ImportanceLevel>(HttpStatusCode.OK, value);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }
    }
}

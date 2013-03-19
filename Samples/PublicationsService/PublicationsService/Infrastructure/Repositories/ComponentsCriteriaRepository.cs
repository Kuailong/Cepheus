using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Procad.DataAccess.RepositoryBase;
using Promob.Entities;
using Procad.DataAccess.Interfaces;

namespace PublicationsService.Infrastructure
{
    public class ComponentsCriteriaRepository : Repository<ComponentCriteria>
    {
        #region Constructor

        public ComponentsCriteriaRepository(IUnitOfWork context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        public List<ComponentCriteria> GetComponentsCriterias(int productId, int accountId, int subGroupId)
        {
            var componentCriterias = new List<ComponentCriteria>();

            var componentCriteria = this.Get(
                    e =>
                        (e.AccountId == accountId || e.AccountId == 0) &&
                        (e.ProductId == productId || e.ProductId == 0) &&
                        (e.SubGroupId == subGroupId || e.SubGroupId == 0),
                    p => p.Publication
                    );

            componentCriterias.AddRange(componentCriteria);

            return componentCriterias;
        }

        public List<ComponentCriteria> GetComponentsCriterias(int publicationId)
        {
            return this.Get(e => e.Publication.PublicationId == publicationId, e => e.Publication)
                .ToList();
        }

        #endregion
    }
}
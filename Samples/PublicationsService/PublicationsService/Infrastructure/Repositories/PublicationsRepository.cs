using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PublicationsService.App_Start;
using System.Net.Http.Headers;
using Promob.Entities;
using Procad.DataAccess.Interfaces;
using PublicationsService.Models;
using Procad.DataAccess.RepositoryBase;

namespace PublicationsService.Infrastructure
{
    public class PublicationsRepository : Repository<Publication>
    {
        #region Constructor

        public PublicationsRepository(IUnitOfWork context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        public List<Publication> GetPublications(List<int> publicationsId)
        {
            var publications = new List<Publication>();
            var publication = this.Get(e => publicationsId.Contains(e.PublicationId), p => p.Component);

            publications.AddRange(publication);

            return publications;
        }

        

        #endregion
    }
}
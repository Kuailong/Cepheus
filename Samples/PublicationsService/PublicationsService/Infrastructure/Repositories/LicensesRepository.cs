using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Procad.DataAccess.RepositoryBase;
using Promob.Entities;
using Procad.DataAccess.Services;
using PublicationsService.App_Start;

namespace PublicationsService.Infrastructure
{
    public class LicensesRepository : ResourcesRepository<License>
    {
        #region Constructor

        public LicensesRepository(WebApiRequester webApiRequester)
            : base(webApiRequester)
        {

        }

        #endregion

        #region Public Methods

        public License GetLicenseBySerialNumber(string serialNumber)
        {
            var relativeUri = string.Format("{0}/{1}", AppSettingsConfig.WebApiLicenses, serialNumber);
            var result = this.Get(relativeUri);

            return result;
        }

        #endregion
    }
}
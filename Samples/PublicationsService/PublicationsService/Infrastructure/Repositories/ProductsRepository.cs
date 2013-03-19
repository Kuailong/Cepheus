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
    public class ProductsRepository : ResourcesRepository<Product>
    {
        #region Constructor

        public ProductsRepository(WebApiRequester webApiRequester)
            : base(webApiRequester)
        {

        }

        #endregion

        #region Public Methods

        public Product GetProductByERPProductID(int erpProductID)
        {
            try
            {
                var filter = string.Format("ERPProduct/ProductID eq {0}", erpProductID);
                var result = this.GetMany(AppSettingsConfig.WebApiProducts, oDataParameters: new { filter = filter });
                return result.FirstOrDefault();
            }
            catch
            {
                return new Product();
            }
        }

        public Product GetProductByProductID(int productID)
        {
            var relativeUri = string.Format("{0}/{1}", AppSettingsConfig.WebApiProducts, productID);
            var result = this.Get(relativeUri);

            return result;
        }

        #endregion
    }
}
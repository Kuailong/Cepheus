using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Promob.Entities;
using Procad.DataAccess.Interfaces;
using System.Net.Http.Headers;
using Procad.DataAccess.Services;
using Promob.Entities.Enums;
using PublicationsService.Infrastructure.Extensions;

namespace PublicationsService.Infrastructure
{
    public class PublicationPackagesRepository
    {
        readonly IUnitOfWork _context;
        private LicensesRepository _licensesRepository;
        private ProductsRepository _productsRepository;

        #region Constructor

        public PublicationPackagesRepository(IUnitOfWork context)
        {
            this._context = context;
            var requester = new WebApiRequester(new MediaTypeWithQualityHeaderValue("application/json"));
            this._licensesRepository = new LicensesRepository(requester);
            this._productsRepository = new ProductsRepository(requester);
        }

        #endregion

        #region Public Methods

        public PublicationsPackage GetPublicationPackagesByCriterias(int productId, int accountId, string serialNumber)
        {
            var publications = this.GetPublicationsIdByCriteria(productId, accountId, serialNumber);
            if (publications == null)
                return null;
            
            return this.GetPublicationPackages(publications);
        }

        public PublicationsPackage GetPublicationPackages(List<Publication> publications)
        {
            if (publications == null || publications.Count <= 0)
                return null;

            var publicationPackages = new PublicationsPackage();

            var publicationPackageItem = (from e in publications
                                            select new PublicationPackageItem
                                            {
                                                BaseUrl = e.StorageUri,
                                                RelativeUrl = e.StorageRelativeFilesPath,
                                                PublicationId = e.PublicationId,
                                                ComponentId = e.Component.ComponentId,
                                                ComponentName = e.Component.Name,
                                                PublicationDescription = e.Description,
                                                PublicationDate = e.PublicationDate,
                                                Lenght = e.Lenght,
                                                IsVisibleOnUI = e.Component.ComponentType.IsVisibleOnUI,
                                                PublicationVersion = e.Version,
                                                eComponentType = this.GetComponentType(e.Component.ComponentType.ComponentTypeId)
                                            }
                                        );

            publicationPackages.AddRange(publicationPackageItem);

            return publicationPackages;
        }

        #endregion

        #region Private Methods

        private List<Publication> GetPublicationsIdByCriteria(int productId, int accountId, string serialNumber)
        {
            if ((productId <= 0 && accountId <= 0) && !string.IsNullOrEmpty(serialNumber))
            {
                var license = this._licensesRepository.GetLicenseBySerialNumber(serialNumber);
                if (license == null)
                    return null;

                productId = this._productsRepository.GetProductByERPProductID(license.CurrentContract.ERPProductID).ProductId;
                accountId = license.CurrentContract.AccountId.Value;
            }

            var product = productId == 0 ? null : this._productsRepository.GetProductByProductID(productId);
            int subGroupId = product == null ? 0 : Int32.Parse(product.ERPProduct.SubGroup.SubGroupId);

            var componentCriterias = new ComponentsCriteriaRepository(this._context).GetComponentsCriterias(productId, accountId, subGroupId);
            if (componentCriterias == null || componentCriterias.Count <= 0)
                return null;

            var publications = this.RemoveOutdatedPublications(componentCriterias);

            return publications;
        }

        private List<Publication> RemoveOutdatedPublications(List<ComponentCriteria> criterias)
        {
            var distinctComponentId = criterias.Select(c => c.Publication.Component.ComponentId).Distinct();
            if (distinctComponentId == null || distinctComponentId.Count() <= 0)
                return null;

            var result = new List<Publication>();

            foreach (var componentId in distinctComponentId)
            {
                var updatedPublication = new ComponentCriteria();

                foreach (var item in criterias.Where(p => p.Publication.Component.ComponentId == componentId))
                {
                    if (updatedPublication.Publication == null)
                    {
                        updatedPublication = item;
                        continue;
                    }

                    if (item.Publication.Active)
                    {
                        if ((!(item.IsHignRelevant ^ updatedPublication.IsHignRelevant) && 
                                (item.Publication.Version.CompareVersion(updatedPublication.Publication.Version) >= 0)) || 
                            (item.IsHignRelevant && !updatedPublication.IsHignRelevant) ||
                            !updatedPublication.Publication.Active)
                            updatedPublication = item;
                    }
                }

                if (updatedPublication.Publication.Active)
                    result.Add(updatedPublication.Publication);
            }

            return result;
        }

        private eComponentType GetComponentType(int componentTypeId)
        {
            return (eComponentType)Enum.ToObject(typeof(eComponentType), componentTypeId);
        }

        #endregion
    }
}
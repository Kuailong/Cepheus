using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Cepheus.DataAccess.Entities;

namespace Cepheus.DataAccess
{
    public class ResourcesRepository
    {
        #region Private Members

        private WebApiRequester _webApiRequester;

        #endregion

        #region Constructor

        public ResourcesRepository(WebApiRequester webApiRequester)
        {
            this._webApiRequester = webApiRequester;
        }

        #endregion

        #region IResourcesRepository Members

        public ResourceResult<T> Get<T>(string resourceEndpoint)
        {
            return this.Get<T>(resourceEndpoint, null, null);
        }
        public ResourceResult<T> Get<T>(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content = response.Content.ReadAsStringAsync().Result;

            return new ResourceResult<T>(response, content);
        }

        public ResourceResult<IEnumerable<T>> GetMany<T>(string resourceEndpoint)
        {
            return this.GetMany<T>(resourceEndpoint, null, null);
        }
        public ResourceResult<IEnumerable<T>> GetMany<T>(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content = response.Content.ReadAsStringAsync().Result;

            return new ResourceResult<IEnumerable<T>>(response, content);
        }

        public HttpResponseMessage Post<T>(string resourceEndpoint, T data)
        {
            var httpContent = new StringContent(Serializer.Serialize(data), Encoding.UTF8);
            var response = this._webApiRequester.RequestResource(resourceEndpoint, HttpMethod.Post, httpContent);

            return response;
        }

        public HttpResponseMessage Put<T>(string resourceEndpoint, T data)
        {
            var httpContent = new StringContent(Serializer.Serialize(data), Encoding.UTF8);
            var response = this._webApiRequester.RequestResource(resourceEndpoint, HttpMethod.Put, httpContent);

            return response;
        }

        public HttpResponseMessage Delete(string resourceEndpoint)
        {
            return this._webApiRequester.RequestResource(resourceEndpoint, HttpMethod.Delete);
        }

        #endregion
    }

    public class ResourcesRepository<T>
    {
        #region Private Members

        private WebApiRequester _webApiRequester;

        #endregion

        #region Constructor

        public ResourcesRepository(WebApiRequester webApiRequester)
        {
            this._webApiRequester = webApiRequester;
        }

        #endregion

        #region IResourcesRepository<T> Members

        public ResourceResult<T> Get(string resourceEndpoint)
        {
            return this.Get(resourceEndpoint, null, null);
        }

        public ResourceResult<T> Get(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content = response.Content.ReadAsStringAsync().Result;

            return new ResourceResult<T>(response, content);
        }

        public ResourceResult<IEnumerable<T>> GetMany(string resourceEndpoint)
        {
            return this.GetMany(resourceEndpoint, null, null);
        }

        public ResourceResult<IEnumerable<T>> GetMany(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content = response.Content.ReadAsStringAsync().Result;

            return new ResourceResult<IEnumerable<T>>(response, content);
        }

        public HttpResponseMessage Post(string resourceEndpoint, T data)
        {
            var httpContent = new StringContent(Serializer.Serialize(data), Encoding.UTF8);
            var response = this._webApiRequester.RequestResource(resourceEndpoint, HttpMethod.Post, httpContent);

            return response;
        }

        public HttpResponseMessage Put(string resourceEndpoint, T data)
        {
            var httpContent = new StringContent(Serializer.Serialize(data), Encoding.UTF8);
            var response = this._webApiRequester.RequestResource(resourceEndpoint, HttpMethod.Put, httpContent);

            return response;
        }

        public HttpResponseMessage Delete(string resourceEndpoint)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, HttpMethod.Delete);

            return response;
        }

        #endregion
    }
}

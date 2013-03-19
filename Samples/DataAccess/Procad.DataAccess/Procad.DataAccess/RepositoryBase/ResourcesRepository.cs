using System;
using System.Collections.Generic;
using Procad.DataAccess.Infrastructure;
using Procad.DataAccess.Interfaces;
using Procad.DataAccess.Services;
using System.Net.Http;
using System.Text;

namespace Procad.DataAccess.RepositoryBase
{
    public class ResourcesRepository : IResourcesRepository 
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

        public T Get<T>(string resourceEndpoint)
        {
            return this.Get<T>(resourceEndpoint, null, null);
        }
        public T Get<T>(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content  = response.Content.ReadAsStringAsync().Result;

            return Serializer<T>.Deserialize(content);            
        }

        public IEnumerable<T> GetMany<T>(string resourceEndpoint)
        {
            return this.GetMany<T>(resourceEndpoint, null, null);
        }
        public IEnumerable<T> GetMany<T>(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content = response.Content.ReadAsStringAsync().Result;

            return Serializer<IEnumerable<T>>.Deserialize(content);
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

    public class ResourcesRepository<T> : IResourcesRepository<T>
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

        public T Get(string resourceEndpoint)
        {
            return this.Get(resourceEndpoint, null, null);            
        }

        public T Get(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content = response.Content.ReadAsStringAsync().Result;

            return Serializer<T>.Deserialize(content);
        }

        public IEnumerable<T> GetMany(string resourceEndpoint)
        {
            return this.GetMany(resourceEndpoint, null, null);
        }

        public IEnumerable<T> GetMany(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            var response = this._webApiRequester.RequestResource(resourceEndpoint, parameters, oDataParameters);
            var content = response.Content.ReadAsStringAsync().Result;

            return Serializer<IEnumerable<T>>.Deserialize(content);
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
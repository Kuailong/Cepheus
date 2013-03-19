using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Procad.DataAccess.Enums;
using Procad.DataAccess.Extensions;
using System.Net;

namespace Procad.DataAccess.Services
{    
    public class WebApiRequester
    {
        #region Private Members

        private MediaTypeWithQualityHeaderValue _mediaType;

        #endregion

        #region Public Properties

        public HttpClientHandler RequestHandler { get; set; }

        #endregion

        #region Constructor

        public WebApiRequester(eMediaType mediaType)
        {
            var type = string.Empty;

            switch (mediaType)
            {
                case eMediaType.Json:
                    type = "application/json";
                    break;
                default:
                    throw new Exception("Unsupported media type");
            }

            this._mediaType = new MediaTypeWithQualityHeaderValue(type);
        }

        public WebApiRequester(eMediaType mediaType, HttpClientHandler handler)
            : this(mediaType)
        {
            this.RequestHandler = handler;
        }

        public WebApiRequester(eMediaType mediaType, NetworkCredential credentials)
            : this(mediaType)
        {
            this.RequestHandler = new HttpClientHandler() { Credentials = credentials };
        }

        #endregion

        #region Public Methods

        public HttpResponseMessage RequestResource(string resourceEndpoint)
        {
            return this.RequestResource(resourceEndpoint, HttpMethod.Get);
        }
        public HttpResponseMessage RequestResource(string resourceEndpoint, HttpClientHandler handler)
        {
            return this.RequestResource(resourceEndpoint, HttpMethod.Get);
        }
        public HttpResponseMessage RequestResource(string resourceEndpoint, object parameters = null, object oDataParameters = null)
        {
            if (string.IsNullOrEmpty(resourceEndpoint))
                throw new ArgumentNullException("resourceEndpoint", "The value can not be null");

            var requestUri = new Uri(resourceEndpoint);

            return this.RequestResource(requestUri, HttpMethod.Get, null, parameters, oDataParameters);
        }
        public HttpResponseMessage RequestResource(string resourceEndpoint, HttpMethod httpMethod)
        {
            return this.RequestResource(resourceEndpoint, httpMethod, null);
        }
        public HttpResponseMessage RequestResource(string resourceEndpoint, HttpMethod httpMethod, HttpContent httpContent)
        {
            if (string.IsNullOrEmpty(resourceEndpoint))
                throw new ArgumentNullException("resourceEndpoint", "The value can not be null");

            var requestUri = new Uri(resourceEndpoint);

            return this.RequestResource(requestUri, httpMethod, httpContent);
        }

        public HttpResponseMessage RequestResource(
            Uri requestUri,
            HttpMethod httpMethod,
            HttpContent httpContent,
            object parameters = null,
            object oDataParameters = null)
        {
            requestUri = requestUri.BuildRequestUri(parameters, oDataParameters);

            var apiHttpMethod = httpMethod.ToApiAllowedHttpMethod();

            HttpResponseMessage response = null;
            using (var client = this.RequestHandler == null ? new HttpClient() : new HttpClient(this.RequestHandler, false))
            {
                client.DefaultRequestHeaders.Accept.Add(this._mediaType);

                switch (apiHttpMethod)
                {
                    case eApiHttpMethod.GET:
                        response = client.GetAsync(requestUri).Result;

                        break;
                    case eApiHttpMethod.POST:
                        if (httpContent == null)
                            throw new ArgumentNullException("httpRequestMessage", "The value can not be null");

                        httpContent.Headers.ContentType = this._mediaType;
                        response = client.PostAsync(requestUri, httpContent).Result;

                        break;
                    case eApiHttpMethod.PUT:
                        if (httpContent == null)
                            throw new ArgumentNullException("httpRequestMessage", "The value can not be null");

                        httpContent.Headers.ContentType = this._mediaType;
                        response = client.PutAsync(requestUri, httpContent).Result;

                        break;
                    case eApiHttpMethod.DELETE:
                        response = client.DeleteAsync(requestUri).Result;

                        break;
                }

                if (response == null)
                    throw new ArgumentNullException("response", "The value can not be null");

                if (!response.IsSuccessStatusCode)
                    throw new HttpResponseException(response);

                return response;
            }
        }

        public void ResetCredentials(string userName, string password)
        {
            this.ResetCredentials(new NetworkCredential(userName, password));
        }
        public void ResetCredentials(NetworkCredential credentials)
        {
            if (this.RequestHandler == null)
                this.RequestHandler = new HttpClientHandler();

            this.RequestHandler.Credentials = credentials;
        }

        #endregion
    }
}
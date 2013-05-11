using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Cepheus.DataAccess.Enums;

namespace Cepheus.DataAccess
{
    public class WebApiRequester
    {
        #region Private Members

        private MediaTypeWithQualityHeaderValue _mediaType;

        #endregion

        #region Public Properties

        public HttpClientHandler RequestHandler { get; set; }
        public Dictionary<string, string> Headers { get; set; }

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

        public WebApiRequester(eMediaType mediaType, Dictionary<string,string> headers)
            : this(mediaType)
        {
            this.Headers = headers;
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
                if (this.Headers != null)
                {
                    foreach (var item in Headers)
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

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

    public static class UriExtensions
    {
        public static Uri BuildRequestUri(this Uri requestUri, object parameters, object oDataParameters)
        {
            if (requestUri == null)
                throw new ArgumentNullException("requestUri", "The value can not be null");

            string uriParams = string.Empty;
            parameters = parameters.ToUriParameters();
            oDataParameters = oDataParameters.ToOdataParameters();

            if (!string.IsNullOrEmpty((string)parameters) && !string.IsNullOrEmpty((string)oDataParameters))
                uriParams = string.Concat(parameters, "&", oDataParameters);
            else
                uriParams = string.Concat(parameters, oDataParameters);

            if (!string.IsNullOrEmpty(uriParams))
                requestUri = new Uri(string.Concat(requestUri.AbsoluteUri, "?", uriParams));

            return requestUri;
        }
    }

    public static class ObjectExtensions
    {
        public static string ToUriParameters(this Object that, string paramPrefix = null)
        {
            if (that == null)
                return null;

            bool firstParameter = true;
            StringBuilder strBuilder = new StringBuilder();

            var props = that.GetType().GetProperties();
            foreach (var p in props)
            {
                if (!firstParameter)
                    strBuilder.Append("&");
                else
                    firstParameter = false;

                if (!string.IsNullOrEmpty(paramPrefix))
                    strBuilder.Append(paramPrefix);

                strBuilder.Append(p.Name);
                var value = p.GetValue(that, null);
                strBuilder.Append("=");
                strBuilder.Append(value);
            }

            var result = strBuilder.ToString();
            if (string.IsNullOrEmpty(result))
                return string.Empty;

            return result;
        }

        public static string ToOdataParameters(this Object that)
        {
            return ToUriParameters(that, "$");
        }
    }

    public static class HttpMethodExtensions
    {
        public static eApiHttpMethod ToApiAllowedHttpMethod(this HttpMethod that)
        {
            if (that.Equals(HttpMethod.Get))
                return eApiHttpMethod.GET;

            if (that.Equals(HttpMethod.Post))
                return eApiHttpMethod.POST;

            if (that.Equals(HttpMethod.Put))
                return eApiHttpMethod.PUT;

            if (that.Equals(HttpMethod.Delete))
                return eApiHttpMethod.DELETE;

            throw new NotSupportedException("HttpMethod not supported by the Api");
        }
    }
}

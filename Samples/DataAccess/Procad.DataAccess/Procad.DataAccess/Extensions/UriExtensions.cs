using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Procad.DataAccess.Extensions
{
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
}

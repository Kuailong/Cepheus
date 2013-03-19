using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Procad.DataAccess.Enums;

namespace Procad.DataAccess.Extensions
{
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

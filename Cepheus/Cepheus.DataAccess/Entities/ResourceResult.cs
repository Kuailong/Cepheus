using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Cepheus.DataAccess.Entities
{
    public class ResourceResult<T>
    {
        public T Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public HttpResponseException Exception { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }

        public ResourceResult(HttpResponseMessage response, string content)
        {
            this.ResponseMessage = response;
            this.StatusCode = response.StatusCode;
            this.IsSuccessStatusCode = response.IsSuccessStatusCode;
            if (this.IsSuccessStatusCode)
                this.Content = Serializer<T>.Deserialize(content);
            else
                this.Exception = new HttpResponseException(response);
        }
    }
}

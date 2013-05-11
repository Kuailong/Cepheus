using Cepheus.App_Start;
using Cepheus.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cepheus.Controllers
{
    [BasicHttpAuthorize]
    public class TokenController : ApiController
    {
        public string Get()
        {
            var key = string.Format("{0}:{1}", AppSettingsConfig.PreToken, DateTime.Now.ToShortDateString());
            var token = RSAClass.Encrypt(key);
            return token;
        }
    }
}

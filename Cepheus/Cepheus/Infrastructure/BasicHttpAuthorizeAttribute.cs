using Cepheus.Entities;
using Cepheus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Cepheus.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicHttpAuthorizeAttribute : AuthorizeAttribute
    {
        #region Public Properties

        public string User { get; set; }
        public string Password { get; set; }

        #endregion

        #region Constants

        private const string BasicAuthResponseHeader = "WWW-Authenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";

        #endregion

        #region Private Properties

        private Repository<User> _userRepository;

        #endregion

        #region Override Methods

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");

            if (AuthorizationDisabled(actionContext) || this.AuthorizeRequest(actionContext.ControllerContext.Request))
                return;

            this.HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");

            actionContext.Response = this.CreateUnauthorizedResponse(actionContext.ControllerContext.Request);
        }

        #endregion

        #region Private Methods

        private static bool AuthorizationDisabled(HttpActionContext actionContext)
        {
            if (!actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return actionContext.ControllerContext
                    .ControllerDescriptor
                    .GetCustomAttributes<AllowAnonymousAttribute>().Any();
            else
                return true;
        }

        private HttpResponseMessage CreateUnauthorizedResponse(HttpRequestMessage request)
        {
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                RequestMessage = request
            };

            result.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
            return result;
        }

        private bool AuthorizeRequest(HttpRequestMessage request)
        {
            AuthenticationHeaderValue authValue = request.Headers.Authorization;
            if (authValue == null || String.IsNullOrWhiteSpace(authValue.Parameter) ||
                String.IsNullOrWhiteSpace(authValue.Scheme) ||
                authValue.Scheme != BasicAuthResponseHeaderValue)
            {
                return false;
            }

            string[] parsedHeader = ParseAuthorizationHeader(authValue.Parameter);
            if (parsedHeader == null)
                return false;

            IPrincipal principal = null;
            if (TryCreatePrincipal(parsedHeader[0], parsedHeader[1], out principal))
            {
                HttpContext.Current.User = principal;
                return true;
            }
            else
                return false;
        }

        private string[] ParseAuthorizationHeader(string authHeader)
        {
            var credentials = Encoding.ASCII.GetString(Convert.FromBase64String(authHeader)).Split(new[] { ':' });

            if (credentials.Length != 2 ||
                string.IsNullOrEmpty(credentials[0]) ||
                string.IsNullOrEmpty(credentials[1]))
                return null;

            return credentials;
        }

        private bool TryCreatePrincipal(string user, string password, out IPrincipal principal)
        {
            principal = null;
            this._userRepository = new Repository<User>(new CepheusContext());
            var basicHttpAuthenticationUser = this._userRepository.Get(e => e.NameUser == user)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(this.User) && !string.IsNullOrEmpty(this.Password))
            {
                basicHttpAuthenticationUser.NameUser = this.User;
                basicHttpAuthenticationUser.Key = CriptoHelper.CreateKey(this.User, this.Password);
            }
            var key = CriptoHelper.CreateKey(user, password);
            if (!user.Equals(basicHttpAuthenticationUser.NameUser, StringComparison.InvariantCulture) ||
                !key.Equals(basicHttpAuthenticationUser.Key))
                return false;

            var identity = new GenericIdentity(user);
            principal = new GenericPrincipal(identity, null);

            return true;
        }

        #endregion
    }    
}
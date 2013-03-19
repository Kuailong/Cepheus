using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace PublicationsService.App_Start
{
    public class AppSettingsConfig
    {
        #region Configurations

        //WebApiUri
        public static readonly string WebApiProducts = ConfigurationManager.AppSettings["WebApiProducts"];
        public static readonly string WebApiERPProducts = ConfigurationManager.AppSettings["WebApiERPProducts"];
        public static readonly string WebApiLicenses = ConfigurationManager.AppSettings["WebApiLicenses"];

        //app
        public static readonly string ClientValidationEnabled = ConfigurationManager.AppSettings["ClientValidationEnabled"];
        public static readonly string UnobtrusiveJavaScriptEnabled = ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"];
        public static readonly string PreserveLoginUrl = ConfigurationManager.AppSettings["PreserveLoginUrl"];

        #endregion
    }
}
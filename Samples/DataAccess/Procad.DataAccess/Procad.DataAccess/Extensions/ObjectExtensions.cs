using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Procad.DataAccess.Extensions
{
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
}

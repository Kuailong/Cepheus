using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Procad.DataAccess.DataAnnotations.Attributes;

namespace Procad.DataAccess.Infrastructure
{
    public static class GetCustomAttributesActivity<T> where T : Attribute
    {
        public static string[] Execute(PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException("PropertyInfo", "The value cannot be null");

            object[] atts = property.GetCustomAttributes(typeof(T), false);
            return Execute_GetAttributeValues(atts);
        }

        private static string[] Execute_GetAttributeValues(object[] attributes)
        {
            List<string> attributesValues = new List<string>();

            foreach (var att in attributes)
                if (typeof(T) == typeof(DataBaseColumnMapAttribute))
                    attributesValues.Add(((DataBaseColumnMapAttribute)att).ColumnName);
                else if (typeof(T) == typeof(DataBaseColumnMapPrefixAttribute))
                    attributesValues.Add(((DataBaseColumnMapPrefixAttribute)att).PrefixName);

            if (attributesValues.Count == 0)
                return null;

            return attributesValues.ToArray();
        }
    }
}

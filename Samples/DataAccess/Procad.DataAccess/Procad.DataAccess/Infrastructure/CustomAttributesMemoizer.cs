using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Procad.DataAccess.Infrastructure
{
    public static class CustomAttributesMemoizer<T> where T : Attribute
    {
        private static Dictionary<Type, Dictionary<PropertyInfo, string[]>> _columnMapAttributes;

        public static string[] GetAttributesValues(Type entityType, PropertyInfo property)
        {
            if (property == null)
                throw new ArgumentNullException("PropertyInfo", "The value cannot be null");
            if (entityType == null)
                throw new ArgumentNullException("Type", "The value cannot be null");

            if (_columnMapAttributes == null)
                _columnMapAttributes = new Dictionary<Type, Dictionary<PropertyInfo, string[]>>();

            if (_columnMapAttributes.ContainsKey(entityType) && _columnMapAttributes[entityType].ContainsKey(property))
                return _columnMapAttributes[entityType][property];

            var customAttributes = GetCustomAttributesActivity<T>.Execute(property);

            Memoize(entityType, property, customAttributes);
            return customAttributes;
        }

        private static void Memoize(Type entityType, PropertyInfo property, string[] customAttributes)
        {
            if (!_columnMapAttributes.ContainsKey(entityType))
                _columnMapAttributes.Add(entityType, new Dictionary<PropertyInfo,string[]>());
                
            _columnMapAttributes[entityType].Add(property, customAttributes);
        }
    }
}

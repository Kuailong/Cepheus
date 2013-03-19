using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Procad.DataAccess.DataAnnotations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DataBaseColumnMapPrefixAttribute : Attribute
    {
        #region Properties

        string m_prefixName = null;
        public string PrefixName
        {
            get
            {
                return m_prefixName;
            }
            private set
            {
                if (value == null || value == String.Empty)
                    throw new FormatException("DataBaseColumnMapPrefixAttribute.m_prefixName needs to be setted with a non-null value");
                m_prefixName = value;
            }
        }

        #endregion

        #region Constructor

        public DataBaseColumnMapPrefixAttribute(string prefixName)
        {
            this.PrefixName = prefixName;
        }

        #endregion
    }
}

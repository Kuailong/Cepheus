using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Procad.DataAccess.DataAnnotations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DataBaseColumnMapAttribute : Attribute
    {
        #region Properties

        string m_columnName = null;
        public string ColumnName
        {
            get
            {
                return m_columnName;
            }
            private set
            {
                if (value == null || value == String.Empty)
                    throw new FormatException("DataBaseColumnMapAttribute.ColumnName needs to be setted with a non-null value");
                m_columnName = value;
            }
        }

        #endregion

        #region Constructor

        public DataBaseColumnMapAttribute()
        {

        }

        public DataBaseColumnMapAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }

        #endregion
    }
}

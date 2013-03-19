using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Procad.DataAccess.Interfaces;
using System.Data;
using System.Reflection;
using Procad.DataAccess.DataAnnotations.Attributes;
using Procad.DataAccess.Infrastructure;

namespace Procad.DataAccess.Factories
{
    public class DataReaderFactory<T> : IDataReaderFactory<T>
    {
        #region Private Properties

        private List<string> _dataReaderColumnsName;

        #endregion

        #region Constructor

        public DataReaderFactory()
        {

        }

        #endregion

        #region Public Methods

        public T Fabricate(IDataReader dataReader)
        {
            this._dataReaderColumnsName = this.GetDataReaderColumnsName(dataReader);

            object obj = Fabricate(dataReader, typeof(T), string.Empty);
            if (obj == null) return default(T);

            return (T)obj;
        }

        #endregion

        #region  Private Methods

        private object Fabricate(IDataReader dataReader, Type type, string columnPrefix)
        {
            if (dataReader == null || dataReader.IsClosed) return null;

            object obj = Activator.CreateInstance(type);

            PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            foreach (PropertyInfo item in props)
            {
                string[] attsValues = CustomAttributesMemoizer<DataBaseColumnMapAttribute>.GetAttributesValues(type, item);
                if (attsValues == null) continue;

                foreach (string attVal in attsValues)
                {
                    if (string.IsNullOrEmpty(attVal))
                    {
                        string prefixName = null;

                        string[] attsPrefixValues = CustomAttributesMemoizer<DataBaseColumnMapPrefixAttribute>.GetAttributesValues(type, item);
                        if (attsPrefixValues != null && attsPrefixValues.Length > 0)
                            prefixName = attsPrefixValues.FirstOrDefault();

                        object propObj = Fabricate(dataReader, item.PropertyType, prefixName);

                        this.SetProperty(obj, item, propObj);
                        break;
                    }
                    else if (!this._dataReaderColumnsName.Contains((columnPrefix + attVal).ToLower()))
                    {
                        continue;
                    }
                    else
                    {
                        object value = null;
                        try
                        {
                            value = dataReader[columnPrefix + attVal];
                        }
                        catch { }
                        finally
                        {
                            this.SetProperty(obj, item, value);
                        }
                    }
                }
            }

            return obj;
        }

        private void SetProperty(object obj, PropertyInfo propertyInfo, object value)
        {
            if (propertyInfo == null || obj == null) return;
            if (!propertyInfo.CanWrite) return;
            if (value == null || value == DBNull.Value) return;

            if (propertyInfo.PropertyType.IsEnum)
                propertyInfo.SetValue(obj, Enum.Parse(propertyInfo.PropertyType, value.ToString(), true), null);
            else
                propertyInfo.SetValue(obj, value, null);
        }

        private List<string> GetDataReaderColumnsName(IDataReader dataReader)
        {
            List<string> columnsName = new List<string>();

            for (int i = 0; i < dataReader.FieldCount; i++)
                columnsName.Add(dataReader.GetName(i).ToLower());

            return columnsName;
        }

        #endregion
    }
}

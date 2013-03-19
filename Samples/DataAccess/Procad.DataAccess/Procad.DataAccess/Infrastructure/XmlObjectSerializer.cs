using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Procad.DataAccess.Infrastructure
{
    public class XmlObjectSerializer<T>
    {
        public static void Save(T obj, string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));

            var fileStream = new FileStream(fileName, FileMode.Create);
            try
            {
                serializer.Serialize(fileStream, obj);
            }
            catch { }
            fileStream.Close();
        }
        public static void Save(T obj, string fileName, Encoding encode)
        {
            var serializer = new XmlSerializer(typeof(T));

            var xmlTextWriter = new XmlTextWriter(fileName, encode);
            xmlTextWriter.Formatting = Formatting.Indented;
            try
            {
                serializer.Serialize(xmlTextWriter, obj);
            }
            catch { }
            xmlTextWriter.Close();
        }
        public static void Save(T obj, string fileName, string rootName)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var fileStream = new FileStream(fileName, FileMode.Create);
            try
            {
                serializer.Serialize(fileStream, obj);
            }
            catch { }
            fileStream.Close();
        }
        public static void Save(T obj, string fileName, string rootName, Encoding encode)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var xmlTextWriter = new XmlTextWriter(fileName, encode);
            xmlTextWriter.Formatting = Formatting.Indented;
            try
            {
                serializer.Serialize(xmlTextWriter, obj);
            }
            catch { }
            xmlTextWriter.Close();
        }

        public static T Load(string fileName)
        {
            var deserializer = new XmlSerializer(typeof(T));

            var fileStream = new FileStream(fileName, FileMode.Open);
            T obj;
            try
            {
                obj = (T)deserializer.Deserialize(fileStream);
                fileStream.Close();
                return obj;
            }
            catch (Exception ex)
            {
                fileStream.Close();
                throw ex;
            }
        }
        public static T Load(string fileName, string rootName)
        {
            var deserializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var fileStream = new FileStream(fileName, FileMode.Open);
            T obj;
            try
            {
                obj = (T)deserializer.Deserialize(fileStream);
                fileStream.Close();
                return obj;
            }
            catch (Exception ex)
            {
                fileStream.Close();
                throw ex;
            }
        }
    }
}

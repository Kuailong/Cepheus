using Newtonsoft.Json;

namespace Procad.DataAccess.Infrastructure
{
    public static class Serializer
    {
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }

    public static class Serializer<T>
    {
        public static T Deserialize(string value)
        {
            if (string.IsNullOrEmpty(value))
                return default(T);

            //var result = JsonConvert.DeserializeObject<T>(value);
            var result = JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            if (result == null)
                return default(T);

            return result;
        }
    }
}
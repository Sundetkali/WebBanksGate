using System;
using System.Web;
using Newtonsoft.Json;

namespace WebSite.CustomSignalR
{
    /// <summary>
    /// Своя реализация для кастомной обработки параметра connectionData, т.к. запрещена передача ковычек в url.
    /// Значения приходят в параметре connectionDataName.
    /// </summary>
    public class ConnectionDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = Activator.CreateInstance(objectType);
            var prop = objectType.GetProperty("Name");
            // параметр Name передается через connectionDataName, т.к. ковычки запрещены в Url
            var names = (HttpContext.Current.Request.QueryString["connectionDataName"]??string.Empty).Split(',');
            if (names.Length > 0)
            {
                var index = Convert.ToInt32(reader.Path.TrimStart('[').TrimEnd(']'));
                prop?.SetValue(obj, names[index]);
            }

            reader.Read();

            return obj;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.Name == "ClientHubInfo";
        }
    }
}
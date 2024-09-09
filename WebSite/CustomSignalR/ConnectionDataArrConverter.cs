using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace WebSite.CustomSignalR
{
    /// <summary>
    /// Своя реализация для кастомной обработки параметра connectionData, т.к. запрещена передача ковычек в url.
    /// Значения приходят в параметре connectionDataName.
    /// </summary>
    public class ConnectionDataArrConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            objectType = objectType.GetGenericArguments()[0];
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(objectType));
            var obj = Activator.CreateInstance(objectType);
            list.Add(obj);
            var prop = objectType.GetProperty("Name");
            // параметр Name передается через connectionDataName, т.к. ковычки запрещены в Url
            var names = (HttpContext.Current.Request.QueryString["connectionDataName"]??string.Empty).Split(',');
            while (reader.Read() && reader.TokenType != JsonToken.EndArray)
            {
                var index = Convert.ToInt32(reader.Path.TrimStart('[').TrimEnd(']'));
                prop?.SetValue(obj, names[index]);
                reader.Read();
            }
            
            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.FullName != null && objectType.FullName.StartsWith("System.Collections.Generic.IEnumerable`1[[Microsoft.AspNet.SignalR.Hubs.HubDispatcher+ClientHubInfo");
        }
    }
}
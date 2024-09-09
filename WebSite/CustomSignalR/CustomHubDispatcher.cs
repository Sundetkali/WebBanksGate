using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebSite.CustomSignalR
{
    /// <summary>
    /// Своя реализация для кастомной обработки параметра connectionData, т.к. запрещена передача ковычек в url.
    /// </summary>
    public class CustomHubDispatcher : HubDispatcher
    {
        private static readonly object _lock = new object();

        public CustomHubDispatcher(HubConfiguration configuration) : base(configuration)
        {
        }

        protected override bool AuthorizeRequest(IRequest request)
        {
            lock (_lock)
            {
                var converter = JsonSerializer.Converters.OfType<ConnectionDataConverter>().FirstOrDefault();
                if (converter == null)
                {
                    JsonSerializer.Converters.Add(new ConnectionDataConverter());
                    JsonSerializer.Converters.Add(new ConnectionDataArrConverter());
                }
            }

            return base.AuthorizeRequest(request);
        }
    }
}
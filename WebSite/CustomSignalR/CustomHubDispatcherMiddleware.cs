using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Owin.Middleware;
using Microsoft.Owin;

namespace WebSite.CustomSignalR
{
    /// <summary>
    ///  Своя реализация для создания CustomHubDispatcher. Необходимо для кастомной обработки параметра connectionData, т.к. запрещена передача ковычек в url.
    /// </summary>
    public class CustomHubDispatcherMiddleware : HubDispatcherMiddleware
    {
        HubConfiguration _configuration;

        public CustomHubDispatcherMiddleware(OwinMiddleware next, HubConfiguration configuration) : base(next, configuration)
        {
            _configuration = configuration;
        }
        
        public override Task Invoke(IOwinContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (TryRejectJSONPRequest(_configuration, context))
            {
                // call base 403 StatusCode
                return base.Invoke(context);
            }

            var dispatcher = new CustomHubDispatcher(_configuration);
            dispatcher.Initialize(_configuration.Resolver);
            return dispatcher.ProcessRequest(context.Environment);
        }
        
        internal static bool TryRejectJSONPRequest(ConnectionConfiguration config,
            IOwinContext context)
        {
            // If JSONP is enabled then do nothing
            if (config.EnableJSONP)
                return false;

            string callback = context.Request.Query.Get("callback");

            // The request isn't a JSONP request so do nothing
            if (String.IsNullOrEmpty(callback))
                return false;

            // Disable the JSONP request with a 403
            // context.Response.StatusCode = 403;
            // context.Response.ReasonPhrase = "Disable the JSONP request with a 403";
            return true;
        }
    }
}
using System;
using System.Globalization;
using Microsoft.Owin;
using Nat.Web.Core.System.Mvc;
using Owin;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Compilation;
using System.Web.Configuration;
using System.Web.Mvc;
using Administration_ADM;
using Hangfire;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Owin.Middleware;
using WebSite.App_Start;
using WebSite.CustomSignalR;
using DI = Nat.Web.Core.System.DI;

[assembly: OwinStartup(typeof(WebSite.Startup))]

namespace WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DebugLog.Log.Debug("Startup.Configuration");

            ConfigureAuth(app);

            ModelValidatorProviders.Providers.Remove(ModelValidatorProviders.Providers.FirstOrDefault(m => m is DataAnnotationsModelValidatorProvider));
            ModelValidatorProviders.Providers.Add(new DataAnnotationsModelValidatorProviderExtended());
            
            GlobalConfiguration.Configuration.UseSqlServerStorage(DependencyResolver.Current.GetService<IGetConnection>().DefaultConnectionString());

            app.Map("/signalr", subApp =>
            {
                var extType = typeof(HubDispatcherMiddleware).Assembly.GetType("Owin.OwinExtensions");
                var method = extType.GetMethod("UseSignalRMiddleware", BindingFlags.Static | BindingFlags.NonPublic);
                var genericMethod = method.MakeGenericMethod(typeof(CustomHubDispatcherMiddleware));
                genericMethod.Invoke(null, new object[] {subApp, new object[] {new HubConfiguration()}});
            });
            
            DebugLog.Log.Debug("Startup.Configuration - finish");
        }

        internal static bool SiteMinderEnabled()
        {
            return !string.IsNullOrEmpty(WebConfigurationManager.AppSettings["SiteMinder.Enabled"])
                   && Convert.ToBoolean(WebConfigurationManager.AppSettings["SiteMinder.Enabled"]);
        }
    }
}

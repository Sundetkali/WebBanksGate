using System;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Administration_ADM;
using BanksGateDataModel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Nat.Web.Core.System;
using Nat.Web.Core.System.CMS;
using Nat.Web.Core.System.EventLog;
using Nat.Web.Core.System.Mail;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using WebSite.Security;

namespace WebBanksGate
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            DI.UnityContainer.RegisterType<IGetConnection, DefaultConnections>();

            DI.UnityContainer.RegisterFactory<HttpContextBase>(_ => new HttpContextWrapper(HttpContext.Current));
            DI.UnityContainer.RegisterFactory<HttpRequestBase>(_ => new HttpRequestWrapper(HttpContext.Current.Request));
            DI.UnityContainer.RegisterFactory<HttpResponseBase>(_ => new HttpResponseWrapper(HttpContext.Current.Response));

            DI.UnityContainer.RegisterType<IEventLogService, EventLogService>();
            DI.UnityContainer.RegisterType<IEventLogManager, EventLogManager>();
            DI.UnityContainer.RegisterFactory<DataContext>(c => new DataContext(c.Resolve<IGetConnection>().DefaultConnectionString()));
            DI.UnityContainer.RegisterFactory<IOwinContext>(c => c.Resolve<HttpContextBase>().GetOwinContext());
            DI.UnityContainer.RegisterFactory<IAuthenticationManager>(c => c.Resolve<IOwinContext>().Authentication);
            

            

            DependencyResolver.SetResolver(new UnityDependencyResolver(DI.UnityContainer));
        }
    }
}
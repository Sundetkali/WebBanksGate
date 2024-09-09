using Nat.Web.Core.System.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Nat.Web.Core.System.EventLog;
using BanksGateDataModel;
using BanksGateDataModel.Models;
using log4net.Config;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Nat.Web.Core.Resources;
using Newtonsoft.Json;
using WebBanksGate;
using WebSite.App_Start;
using WebSite.ViewModels;

namespace WebSite
{
    public class MvcApplication : HttpApplication
    {
        private static bool LogEnabled()
        {
            return !string.IsNullOrEmpty(WebConfigurationManager.AppSettings["FileLogEnabled"])
                   && Convert.ToBoolean(WebConfigurationManager.AppSettings["FileLogEnabled"]);
        }

        private EventLogManager Log { get; set; }

        protected void Application_Start()
        {
            DebugLog.Log.Debug("Application_Start");
            ModelBinders.Binders.Add(typeof(DateTime), new DateModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new DateModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            WebSiteUnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            if (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["SkipBundles"]) || !bool.Parse(WebConfigurationManager.AppSettings["SkipBundles"]))
                BundleConfig.RegisterBundles(BundleTable.Bundles);

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "ValidationResources";
            DefaultModelBinder.ResourceClassKey = "ValidationResources";
            DebugLog.Log.Debug("Application_Start-finish");
            DebugLog.InitLogger(LogEnabled());
        }

        private string StateInfo()
        {
            if (!LogEnabled())
                return "";
            return
                $",\t{{ User.Identity.IsAuthenticated: '{User?.Identity?.IsAuthenticated}', User.Identity.Name: '{User?.Identity?.Name}', Context.Request.ServerVariables.HTTP_SM_USER: '{Context.Request.ServerVariables["HTTP_SM_USER"]}', Context.Items.Keys: '{string.Join(";", Context.Items.Keys.OfType<string>())}', Context.Request.Url: '{Context.Request.Url}', Context.Response.StatusCode: {Context.Response.StatusCode}, Context.Response.RedirectLocation: '{Context.Response.RedirectLocation}' }}";
        }

        private string FullStateInfo()
        {
            if (!LogEnabled())
                return "";

            var appState = string.Join(";", Context.Application.AllKeys);
            var cookies = string.Join(";", Context.Request.Cookies.AllKeys);
            var rParams = string.Join(";", Context.Request.Params.AllKeys);
            string sessionKeys;
            try
            {
                sessionKeys = string.Join(";", Context.Session?.Keys.OfType<string>() ?? new string[0]);
            }
            catch (Exception e)
            {
                sessionKeys = e.Message;
            }

            return $",\t{{ Context.Request.Cookies.AllKeys: '{cookies}', Context.Session.Keys: '{sessionKeys}', Context.Application.AllKeys: '{appState}', Context.Request.Params.AllKeys: '{rParams}' }}";
        }

        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            DebugLog.Log.Debug("Application_AuthorizeRequest" + StateInfo());
            //DebugLog.Log.Debug("Application_AuthorizeRequest-FullInfo" + FullStateInfo());
            if (Startup.SiteMinderEnabled())
            {
                var message = Request.ServerVariables["HTTP_SM_USERMSG"];
                var userName = Request.ServerVariables["HTTP_SM_USER"];
                if (!string.IsNullOrEmpty(message))
                {
                    if (string.IsNullOrEmpty(userName))
                        DebugLog.Log.Error("Application_AuthorizeRequest: HTTP_SM_USERMSG=" + message);
                    else
                        DebugLog.Log.Info("Application_AuthorizeRequest: HTTP_SM_USERMSG=" + message);
                }

                if (!string.IsNullOrEmpty(userName) && (!(User?.Identity?.IsAuthenticated ?? false) || !userName.Equals(User?.Identity?.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    // var manager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                    // var userManager = Context.GetOwinContext().Get<ApplicationUserManager>();

                    // if (User?.Identity?.IsAuthenticated ?? false)
                    // {
                    //     DebugLog.Log.Info("Application_AuthorizeRequest: Authentication.SignOut " + User?.Identity?.Name);
                    //     Context.GetOwinContext().Authentication.SignOut();
                    //     Context.Response.Redirect(Context.Request.RawUrl, true);
                    // }
                    //
                    // var user = userManager.FindByName(userName);
                    // if (user != null)
                    // {
                    //     DebugLog.Log.Info("Application_AuthorizeRequest: Authentication.SignIn " + userName);
                    //     manager.SignIn(user, false, false);
                    // }
                }
                /*else if (string.IsNullOrEmpty(userName) && (User?.Identity?.IsAuthenticated ?? false))
                {
                    Context.GetOwinContext().Authentication.SignOut();
                    Context.Response.Redirect("~/", true);
                }*/
            }
        }
        
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            DebugLog.Log.Debug("Application_AuthenticateRequest" + StateInfo());
            
            /*if (!User.Identity.IsAuthenticated && !string.IsNullOrEmpty(user))
                FormsAuthentication.SetAuthCookie(user, false, "mcc-auth");*/
            //DebugLog.Log.Debug("Application_AuthenticateRequest-FullInfo" + FullStateInfo());
        }
        
        protected void Application_Error(object sender, EventArgs e)
        {
            DebugLog.Log.Error("Application_Error" + StateInfo(), Context.Error);
            if (Context.Error is HttpAntiForgeryException
                && (User?.Identity?.IsAuthenticated ?? false)
                && Request.HttpMethod == "POST"
                && !string.IsNullOrEmpty(Request.Url.AbsolutePath)
                && Request.Url.AbsolutePath.Equals("/Account/Login"))
            {
                Response.ClearContent();
                Response.StatusCode = 200;
                Response.ContentType = "application/json";
                Response.Output.Write(JsonConvert.SerializeObject(new {success = true}));
                Response.End();
            }
            else if (Context.Error != null
                     && (string.IsNullOrEmpty(WebConfigurationManager.AppSettings["DevDisableErrorPage"]) 
                         || bool.TryParse(WebConfigurationManager.AppSettings["DevDisableErrorPage"], out var disable) && !disable))
            {
                Log.LogException(null, Context.Error);
                var url = $"/Home/Error?method={Request.HttpMethod}&backPath={HttpUtility.UrlEncode(Request.RawUrl)}";
                if (Context.Error is ShowUserMessageException ex)
                    url += "&message=" + HttpUtility.UrlEncode(ex.Message);
                Response.Redirect(url);
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Log = DependencyResolver.Current.GetService<EventLogManager>();
            DebugLog.Log.Debug("Application_BeginRequest" + StateInfo());
            // DebugLog.Log.Debug("Application_BeginRequest-FullInfo" + FullStateInfo());
        }
        
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            DebugLog.Log.Debug("Application_EndRequest" + StateInfo());
            if (Response.StatusCode == 200 && !string.IsNullOrEmpty(Response.Headers["X-Responded-JSON"]))
            {
                if (User?.Identity?.IsAuthenticated ?? false)
                {
                    var vm = JsonConvert.DeserializeObject<XRespondedJsonViewModel>(Response.Headers["X-Responded-JSON"]);
                    vm.headers.authorized = true;
                    Response.Headers["X-Responded-JSON"] = JsonConvert.SerializeObject(vm);
                }
                else if (!string.IsNullOrEmpty(Request.Url.AbsolutePath) && (
                    Request.Url.AbsolutePath.EndsWith("/Create", StringComparison.OrdinalIgnoreCase)
                    || Request.Url.AbsolutePath.EndsWith("/Update", StringComparison.OrdinalIgnoreCase)
                    || Request.Url.AbsolutePath.EndsWith("/Destroy", StringComparison.OrdinalIgnoreCase)))
                {
                    Response.StatusCode = 401;
                }
            }
            DebugLog.Log.Debug("Application_EndRequest - finish" + StateInfo());

            if (Startup.SiteMinderEnabled()
                && !(User?.Identity?.IsAuthenticated ?? false)
                && Response.StatusCode == 302
                && !string.IsNullOrEmpty(Request.Url.AbsolutePath)
                && Request.Url.AbsolutePath != "/"
                && Request.HttpMethod == "POST"
                && !Request.Url.AbsolutePath.Contains("/siteminderagent/"))
            {
                Response.Clear();
                Response.StatusCode = 200;
                var vm = new XRespondedJsonViewModel
                {
                    status = 401,
                    headers = new XRespondedJsonHeadersViewModel {goHome = true}
                };
                Response.Headers["X-Responded-JSON"] = JsonConvert.SerializeObject(vm);
            }

            if (Response.StatusCode == 403 || Response.StatusCode == 401)
            {
                Log.LogException(null, new HttpException(Response.StatusCode, Response.Status + " " + Response.StatusDescription));
            }

            var location = Response.Headers["Location"] ?? Response.RedirectLocation;
            if (Response.StatusCode == 302
                && !string.IsNullOrEmpty(location)
                && (User?.Identity?.IsAuthenticated ?? false)
                && (Startup.SiteMinderEnabled() && location.Contains("/siteminderagent/")
                    || !Startup.SiteMinderEnabled() && location.IndexOf("/Account/Login", StringComparison.OrdinalIgnoreCase) > -1))
            {
                Log.Log(Context.Handler as Controller, () => SharedResources.SAccessDenied, true, null, "AccessDenied", "System");
                Response.Redirect("/Home/AccessDenied?EmptyLayout=" + (Request.QueryString["EmptyLayout"] ?? "false"));
            }
        }
    }
}

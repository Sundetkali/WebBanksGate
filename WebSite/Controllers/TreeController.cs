using System.Web.SessionState;
using Nat.Web.Core.System.CMS;
using Nat.Web.Core.System.Extensions;
using Newtonsoft.Json;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    [SessionState(SessionStateBehavior.Disabled)]
    public class TreeController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            requestContext.SetThreadCulture();
            base.Initialize(requestContext);
        }

        // GET: Tree
        public ActionResult Index(long id, string openId, long? openParam_OpenId, long? openParam_OpenIdSort, string getDataParamsJson, string layoutTitle, bool? hideTabs, long? refChildMenu, bool? hideTreeLeftMenu)
        {
            ViewBag.refChildMenu = refChildMenu ?? id;
            var menu = DependencyResolver.Current.GetService<IMenuService>().GetMenuName(id);
            return View(
                new TreeViewModel
                {
                    id = id,
                    Title = string.IsNullOrEmpty(layoutTitle) ? menu.Name : Properties.Resources.SMenu,
                    LayoutTitle = layoutTitle,
                    IconCss = menu.IconClass,
                    OpenId = openId,
                    OpenDataJson = JsonConvert.SerializeObject(new
                    {
                        openId = openParam_OpenId,
                        openIdSort = openParam_OpenIdSort
                    }),
                    GetDataParamsJson = string.IsNullOrEmpty(getDataParamsJson) ? "{}" : getDataParamsJson,
                    TabCss = hideTabs == true ? "m-hide-tabs" : "",
                    HideTreeLeftMenu = hideTreeLeftMenu ?? false,
                });
        }
    }
}
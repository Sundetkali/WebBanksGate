using System.Web.Mvc;
using System.Web.Optimization;

namespace Dictionaries.Areas.DIC
{
    public class DICAreaRegistration : AreaRegistration
    {
        public override string AreaName => "DIC";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DIC_default",
                "DIC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Dictionaries.Areas.DIC.Controllers" }
            );
            RegisterBundles(BundleTable.Bundles);
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/DIC").Include(
                    "~/Areas/DIC/Scripts/Main.js"));
            bundles.Add(
                new StyleBundle("~/content/DIC/bundle").Include(
                    "~/Areas/DIC/Content/DIC.css"));
        }
    }
}
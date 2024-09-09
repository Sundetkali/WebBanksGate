using System.Web;
using System.Web.Optimization;

namespace WebSite
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/mainscripts").Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js",
                    "~/Scripts/ExtendKendo.js",
                    "~/Scripts/HomeMenu.js",
                    "~/Scripts/MainScripts.js",
                    "~/Scripts/CommonFunctions.js",
                    "~/Scripts/CommonClasses.js",
                    "~/Scripts/BasicMakerChecker.js",
                    "~/Areas/ADM/Scripts/GridSettings.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.signalR-2.4.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/NCALayer").Include(
                        "~/Scripts/NCALayer/*.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Theme.css",
                      "~/Content/Icons.css"));
            
            bundles.Add(
                new StyleBundle("~/content/fontawesome/css/bundle").Include(
                    "~/Content/fontawesome/css/solid.min.css",
                    "~/Content/fontawesome/css/regular.min.css",
                    "~/Content/fontawesome/css/fontawesome.min.css"));

            
            // kendo UI
            bundles.Add(
                new ScriptBundle("~/bundles/kendo-ru").Include(
                    "~/Scripts/kendo/kendo.all.min.js",
                    "~/Scripts/kendo/kendo.aspnetmvc.min.js",
                    "~/Scripts/kendo/cultures/kendo.culture.ru-KZ-custom.min.js",
                    "~/Scripts/kendo/messages/kendo.messages.ru-RU.min.js",
                    "~/Scripts/kendo/messages/kendo.messages.custom.ru-RU.min.js",
                    "~/Scripts/kendo/jszip.min.js",
                    "~/Scripts/Core.ru-RU.js"));
            bundles.Add(
                new ScriptBundle("~/bundles/kendo-kz").Include(
                    "~/Scripts/kendo/kendo.all.min.js",
                    "~/Scripts/kendo/kendo.aspnetmvc.min.js",
                    "~/Scripts/kendo/cultures/kendo.culture.kk-KZ.min.js",
                    "~/Scripts/kendo/messages/kendo.messages.kk-KZ.min.js",
                    "~/Scripts/kendo/jszip.min.js",
                    "~/Scripts/Core.kk-Kz.js"));
            bundles.Add(
                new ScriptBundle("~/bundles/kendo-en").Include(
                    "~/Scripts/kendo/kendo.all.min.js",
                    "~/Scripts/kendo/kendo.aspnetmvc.min.js",
                    "~/Scripts/kendo/cultures/kendo.culture.en-us.min.js",
                    "~/Scripts/kendo/cultures/kendo.culture.en-US-custom.min.js",
                    "~/Scripts/kendo/messages/kendo.messages.en-us.min.js",
                    "~/Scripts/kendo/jszip.min.js",
                    "~/Scripts/Core.en-US.js"));

            bundles.Add(
                new StyleBundle("~/content/kendo/bundle").Include(
                    "~/Content/kendo/kendo.common.min.css",
                    "~/Content/kendo/kendo.bootstrap.min.css"));
            
            bundles.Add(
                new ScriptBundle("~/bundles/home-tree").Include(
                    "~/Scripts/Tree.js"));
            bundles.Add(new StyleBundle("~/content/home-tree/bundle").Include(
                "~/Content/tree.css"));
        }
    }
}

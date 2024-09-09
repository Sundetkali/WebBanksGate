using System.Web.Mvc;
using System.Web.Optimization;

namespace TaxInterface_TI.Areas.DIC
{
    public class TIAreaRegistration : AreaRegistration
    {
        public override string AreaName => "TI";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TI_default",
                "TI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "TaxInterface_TI.Areas.TI.Controllers" }
            );
            RegisterBundles(BundleTable.Bundles);
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/DIC").Include(
                    "~/Areas/TI/Scripts/Main.js",
                    "~/Areas/TI/Scripts/Clients.js",
                    "~/Areas/TI/Scripts/ClientsSelection.js",
                    "~/Areas/TI/Scripts/ClientsInContracts.js",
                    "~/Areas/TI/Scripts/ClientsAccountsInContracts.js",
                    "~/Areas/TI/Scripts/ClientContacts.js",
                    "~/Areas/TI/Scripts/OutlookTemplates.js",
                    "~/Areas/TI/Scripts/UNNB.js",
                    "~/Areas/TI/Scripts/Calendar.js",
                    "~/Areas/TI/Scripts/Signatories.js",
                    "~/Areas/TI/Scripts/ClientBankAccounts.js",
                    "~/Areas/TI/Scripts/BankAccountTypes.js",
                    "~/Areas/TI/Scripts/ClientsMPP.js",
                    "~/Areas/TI/Scripts/ComplianceBankAccounts.js",
                    "~/Areas/TI/Scripts/ComplianceEKNPTreasurys.js",
                    "~/Areas/TI/Scripts/EKNPAccountTransactionCode.js",
                    "~/Areas/TI/Scripts/ClientsForm.js",
                    "~/Areas/TI/Scripts/MailingGroup.js",
                    "~/Areas/TI/Scripts/ClientSendDataExceptions.js",
                    "~/Areas/TI/Scripts/SignersModule.js",
                    "~/Areas/TI/Scripts/EmailMessagesDialog.js",
                    "~/Areas/TI/Scripts/CitistoreTemplates.js",
                    "~/Areas/TI/Scripts/EditTemplates.js",
                    "~/Areas/TI/Scripts/BasicMakerChecker.js",
                    "~/Areas/TI/Scripts/SignatoriesTemplates.js",
                    "~/Areas/TI/Scripts/EconomicTradeType.js",
                    "~/Areas/TI/Scripts/StatementsTranslate.js",
                    "~/Areas/TI/Scripts/ClientBankAccountClassExceptions.js",
                    "~/Areas/TI/Scripts/WeekendMaster.js",
                    "~/Areas/TI/Scripts/Countries.js"
                        ));
            bundles.Add(
                new StyleBundle("~/content/TI/bundle").Include(
                    "~/Areas/TI/Content/TI.css"));
        }
    }
}
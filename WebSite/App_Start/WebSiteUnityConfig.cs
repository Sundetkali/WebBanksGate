
using BanksGateDataModel.Models;
using Nat.Web.Core.System;
using Unity;

namespace WebSite
{
    public class WebSiteUnityConfig
    {
        public static void RegisterComponents()
        {
            // DI.UnityContainer.RegisterFactory<DataContext>(c => new DataContext(c.Resolve<IGetConnection>().DefaultConnectionString()));
            // // DI.UnityContainer.RegisterType<ISmtpClientDefault, CustomSmtpClient>();
            // DI.UnityContainer.RegisterType<ISmtpClientCitiStore, CitiStore>();
            // DI.UnityContainer.RegisterType<ISmtpClientCurrencyControl, CurrencyControl>();
            // DI.UnityContainer.RegisterType<ISmtpClientCurrencyControlAdv, CurrencyControl_ADV>();
            // DI.UnityContainer.RegisterType<ISmtpClientCurrencyControlProc, CurrencyControl_PROC>();
            // DI.UnityContainer.RegisterType<ISmtpClientSignatories, Signatories>();
            // DI.UnityContainer.RegisterType<ISmtpClientAdministration, Administration>();
            // DI.UnityContainer.RegisterType<ISmtpClientDigitalSignature, DigitalSignature>();
            // DI.UnityContainer.RegisterType<ISmtpClientSigningDocument, SigningDocument>();
        }
    }
}
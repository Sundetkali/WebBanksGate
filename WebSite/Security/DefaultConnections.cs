using System.Web.Configuration;
using Administration_ADM;

namespace WebSite.Security
{
     public class DefaultConnections : IGetConnection
    {
        private static string DefaultConnection = "DefaultConnection";
        private static string WbgConnection = "WBGConnection";


        string IGetConnection.DefaultConnectionString()
        {
            if (WebConfigurationManager.ConnectionStrings[WbgConnection] != null)
                return WebConfigurationManager.ConnectionStrings[WbgConnection].ConnectionString;
            return WebConfigurationManager.ConnectionStrings[DefaultConnection].ConnectionString;
        }
    }
}
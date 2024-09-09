using System.Text;
using System.Web.Configuration;

namespace BanksGateDataModel.Settings
{
    public class EncodingSettings
    {
        public static Encoding ReadMT()
        {
            if (int.TryParse(WebConfigurationManager.AppSettings["ReadMT.Encoding"], out var code))
                return Encoding.GetEncoding(code);
            return Encoding.GetEncoding(1251);
        }

        public static Encoding WriteMT()
        {
            if (int.TryParse(WebConfigurationManager.AppSettings["WriteMT.Encoding"], out var code))
                return Encoding.GetEncoding(code);
            return Encoding.GetEncoding(1251);
        }
    }
}
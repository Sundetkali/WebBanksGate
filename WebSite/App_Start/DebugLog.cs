using System.Xml;
using log4net;
using log4net.Config;

namespace WebSite.App_Start
{
    public static class DebugLog
    {
        private const string EnabledLog = @"
  <log4net>
    <appender name=""LogFileAppender"" type=""log4net.Appender.RollingFileAppender"">
      <param name=""File"" value=""App_Data\Logs\WebSiteLog.log"" />
      <param name=""AppendToFile"" value=""true"" />
      <encoding value=""utf-8"" />
      <maxSizeRollBackups value=""100"" />
      <maximumFileSize value=""50MB"" />
      <lockingModel type=""log4net.Appender.FileAppender+MinimalLock"" />
      <layout type=""log4net.Layout.PatternLayout"">
        <param name=""ConversionPattern"" value=""%d  %-5p %m%n"" />
      </layout>
    </appender>
    
    <logger name=""DebugLog"">
      <appender-ref ref=""LogFileAppender"" />
    </logger>
  </log4net>";

        private const string DisabledLog = @"<log4net></log4net>";

        internal static ILog _log = LogManager.GetLogger("DebugLog");

        public static ILog Log => _log;

        public static void InitLogger(bool enabled)
        {
            var d = new XmlDocument();
            d.LoadXml(enabled ? EnabledLog : DisabledLog);
            XmlConfigurator.Configure(d.DocumentElement);
        }
    }
}
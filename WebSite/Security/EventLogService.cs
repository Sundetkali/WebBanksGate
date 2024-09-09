using System;
using System.Threading.Tasks;
using Nat.Web.Core.System.EventLog;

namespace Administration_ADM
{
    public class EventLogService: IEventLogService
    {
        public void Log(string typeCode, string categoryCode, string sourceCode, Type resourceType, string message)
        {
            throw new NotImplementedException();
        }

        public void Log(string typeCode, string categoryCode, string sourceCode, Type resourceType, string message, Func<IEventLogData> getLogData)
        {
            throw new NotImplementedException();
        }

        public Task LogAsync(string typeCode, string categoryCode, string sourceCode, Type resourceType, string message)
        {
            throw new NotImplementedException();
        }

        public Task LogAsync(string typeCode, string categoryCode, string sourceCode, Type resourceType, string message,
            Func<IEventLogData> getLogData)
        {
            throw new NotImplementedException();
        }
    }
}
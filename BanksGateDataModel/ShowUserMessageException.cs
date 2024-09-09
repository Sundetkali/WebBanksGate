using System;
using System.Runtime.Serialization;

namespace BanksGateDataModel
{
    public class ShowUserMessageException : Exception
    {
        public ShowUserMessageException()
        {
        }

        public ShowUserMessageException(string message) : base(message)
        {
        }

        public ShowUserMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShowUserMessageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
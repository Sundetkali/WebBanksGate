using System;

namespace BanksGateDataModel
{
    public class ComputingException : Exception
    {
        public ComputingException(string message) : base(message)
        {
        }

        public ComputingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
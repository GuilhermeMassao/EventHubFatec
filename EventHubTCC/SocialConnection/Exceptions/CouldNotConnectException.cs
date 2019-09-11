using System;

namespace SocialConnection.Exceptions
{
    public class CouldNotConnectException : Exception
    {
        public CouldNotConnectException(string message) : base(message)
        {
        }

        public CouldNotConnectException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
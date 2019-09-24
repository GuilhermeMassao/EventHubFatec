using System;
using System.Net;

namespace SocialConnection.Exceptions
{
    public class CouldNotConnectException : Exception
    {
        public HttpStatusCode ErrorCode { get; set; }
        public CouldNotConnectException(string message, HttpStatusCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class EmailNotContainingAtException : Exception
    {
        public EmailNotContainingAtException()
        {
        }

        public EmailNotContainingAtException(string message) : base(message)
        {
        }

        public EmailNotContainingAtException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailNotContainingAtException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
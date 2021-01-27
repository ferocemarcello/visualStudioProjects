using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class NotContainingSpecialCharException : Exception
    {
        public NotContainingSpecialCharException()
        {
        }

        public NotContainingSpecialCharException(string message) : base(message)
        {
        }

        public NotContainingSpecialCharException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotContainingSpecialCharException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
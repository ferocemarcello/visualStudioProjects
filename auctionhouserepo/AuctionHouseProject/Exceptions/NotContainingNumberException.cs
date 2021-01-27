using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class NotContainingNumberException : Exception
    {
        public NotContainingNumberException()
        {
        }

        public NotContainingNumberException(string message) : base(message)
        {
        }

        public NotContainingNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotContainingNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class NotContainingCapitalLetterException : Exception
    {
        public NotContainingCapitalLetterException()
        {
        }

        public NotContainingCapitalLetterException(string message) : base(message)
        {
        }

        public NotContainingCapitalLetterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotContainingCapitalLetterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
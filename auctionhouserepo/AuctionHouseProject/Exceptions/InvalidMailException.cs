using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class InvalidMailException : Exception
    {
        public InvalidMailException()
        {
        }

        public InvalidMailException(string message) : base(message)
        {
        }

        public InvalidMailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
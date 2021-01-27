using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class DifferentPasswordException : Exception
    {
        public DifferentPasswordException()
        {
        }

        public DifferentPasswordException(string message) : base(message)
        {
        }

        public DifferentPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DifferentPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class AlreadyExistingUserException : Exception
    {
        public AlreadyExistingUserException()
        {
        }

        public AlreadyExistingUserException(string message) : base(message)
        {
        }

        public AlreadyExistingUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyExistingUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class ShortPasswordException : Exception
    {
        private int length;

        public ShortPasswordException()
        {
        }

        public ShortPasswordException(string message) : base(message)
        {
        }

        public ShortPasswordException(int length)
        {
            this.length = length;
        }

        public ShortPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShortPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
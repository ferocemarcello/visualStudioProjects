using System;
using System.Runtime.Serialization;

namespace AuctionHouseProject
{
    [Serializable]
    public class ShortEmailException : Exception
    {
        private int length;

        public ShortEmailException()
        {
        }

        public ShortEmailException(string message) : base(message)
        {
        }

        public ShortEmailException(int length)
        {
            this.length = length;
        }

        public ShortEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShortEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
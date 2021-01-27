using System;
using System.Runtime.Serialization;

namespace Login_Component
{
    [Serializable]
    public class ShortEmailException : Exception
    {
        private int length;

        public ShortEmailException()
        {
            this.length = -1;
        }

        public ShortEmailException(int length)
        {
            this.length = length;
        }
        public string CustomMessage()
        {
            return ("the email is long " + this.length + ";it has to be long 5 at least");
        }
    }
}
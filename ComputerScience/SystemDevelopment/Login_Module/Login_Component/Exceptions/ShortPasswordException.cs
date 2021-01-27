using System;
using System.Runtime.Serialization;

namespace Login_Component
{
    [Serializable]
    public class ShortPasswordException : Exception
    {
        private int length;

        public ShortPasswordException()
        {
            this.length = -1;
        }


        public ShortPasswordException(int length)
        {
            this.length = length;
        }
        public string CustomMessage()
        {
            return ("the password has a length of " + length + "; it has to be long at least 6");
        }
    }
}
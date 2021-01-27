using System;
using System.Runtime.Serialization;

namespace Login_Component
{
    [Serializable]
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
        {
        }

        public string CustomMessage()
        {
            return ("the password doesn't match with the user");
        }
    }
}
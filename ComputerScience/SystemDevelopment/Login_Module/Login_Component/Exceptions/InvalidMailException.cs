using System;
using System.Runtime.Serialization;

namespace Login_Component
{
    [Serializable]
    public class InvalidMailException : Exception
    {
        public InvalidMailException()
        {
        }

        public string CustomMessage()
        {
            return ("there is no user with this mail");
        }
    }
}
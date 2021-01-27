using System;
using System.Runtime.Serialization;

namespace Login_Component
{
    [Serializable]
    public class DifferentPasswordException : Exception
    {
        public DifferentPasswordException()
        {
        }

        public string CustomMessage()
        {
            return "the two passwords are different!";
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component.Exceptions
{
    public class NonExistingUserException : Exception
    {

        public string CustomMessage()
        {
            return "No email matching";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component.Exceptions
{
    public class EmailSyntaxWrongException : Exception
    {

        public string CustomMessage()
        {
            return "The syntax of the email is not valid";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component.Exceptions
{
    public class AlreadyExistingUserException : Exception
    {

        public string CustomMessage()
        {
            return "This user is already existing";
        }

    }
}

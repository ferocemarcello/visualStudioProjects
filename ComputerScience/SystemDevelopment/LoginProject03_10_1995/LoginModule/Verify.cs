using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginModule
{
    class Verify
    {
        public static void bejoEmailChk(string email)
        {
            if (!email.Contains("@"))
            {
                throw new Exception();
            }
        }
        public static void bejoPasswordChk(string password)
        {
            if (password==null)
            {
                throw new Exception();
            }
            if (password <6)
            {
                throw new Exception();
            }
        }
    }
}

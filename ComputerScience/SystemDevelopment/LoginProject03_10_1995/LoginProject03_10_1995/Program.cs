using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginProject03_10_1995
{
    class Program
    {
        static void Main(string[] args)
        {

            LoginModule.LoginModule lm = new LoginModule.LoginModule(new LoginModule.VerifyEmail(LoginModule.VerifyEmail("benny@€al.dk"));
            lm.CreateUser("benny@€al.dk", "1234543", "1234543");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component
{
    public class LoginCommander : ICommand
    {
        private string email;
        private string password;
        private ILoginDataMapper ldm;
        public LoginCommander(string email, string password, ILoginDataMapper ldm)
        {
            this.email = email;
            this.password = password;
            this.ldm = ldm;
        }
        public void Execute()
        {

            Helper.CheckCredentials(email, Helper.GetEncryptedPassword(password), ldm);
        }
    }
}

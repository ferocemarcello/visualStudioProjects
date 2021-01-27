using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component
{
    public class DeleteUserCommander : ICommand
    {
        private string email;
        private string password;
        private ILoginDataMapper ldm;

        public DeleteUserCommander(string email, string password, ILoginDataMapper ldm)
        {
            this.email = email;
            this.password = password;
            this.ldm = ldm;
        }

        public void Execute()
        {
            Helper.CheckEmailSyntax(email);
            Helper.CheckPasswordSyntax(password);
            Helper.Delete(email, Helper.GetEncryptedPassword(password), ldm);
        }
    }
}

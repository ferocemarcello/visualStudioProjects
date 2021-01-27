using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component
{
    public class Login//it should be the invoker
    {
        private ILoginDataMapper ldm;

        public Login(ILoginDataMapper ldm)
        {
            this.ldm = ldm;
        }
        public void CreateUser(string email, string password, string confirmPassword)
        {
            ICommand c = new CreateUserCommand(email, password, confirmPassword, ldm);
            c.Execute();
        }
        public void LoginUser(string email,string Password)
        {
            ICommand c = new LoginCommander(email, Password, ldm);
            c.Execute();
        }

        public void DeleteUser (string email, string password)
        {
            ICommand c = new DeleteUserCommander(email, password, ldm);
            c.Execute();
        }

        public void ResetPassword(string email, string password, string newPassword, string newConfirmPassword)
        {
            ICommand c = new ResetPasswordCommander(email, password, newPassword, newConfirmPassword, ldm);
            c.Execute();
        }

        public void ResetMail(string email,string newMail)
        {
            ICommand c = new ResetMailCommander(email, newMail,ldm);
            c.Execute();
        }
    }
}

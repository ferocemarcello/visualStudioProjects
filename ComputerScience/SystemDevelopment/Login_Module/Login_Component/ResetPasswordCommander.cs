using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component
{
    public class ResetPasswordCommander : ICommand
    {

        private string email;
        private string password;
        private string newPassword;
        private string newPasswordConfirm;
        private ILoginDataMapper ldm;
        
        public ResetPasswordCommander (string email, string password, string newPassword, string newPasswordConfirm, ILoginDataMapper ldm)
        {
            this.email = email;
            this.password = password;
            this.newPassword = newPassword;
            this.newPasswordConfirm = newPasswordConfirm;
            this.ldm = ldm;    
        }
        
        public void Execute()
        {
            Helper.CheckEmailSyntax(email);
            Helper.CheckPasswordSyntax(password);
            Helper.CheckPasswordEqual(newPassword, newPasswordConfirm);
            Helper.ChangePassword(email, password, newPassword, ldm);

        }
    }
}

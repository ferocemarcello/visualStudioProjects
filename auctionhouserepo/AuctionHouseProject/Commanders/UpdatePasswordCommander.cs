using AuctionHouseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    public class UpdatePasswordCommander : ICommand
    {

        private string email;
        private string password;
        private string newPassword;
        private string newPasswordConfirm;
        private MsSqlDataMapper ldm;
        
        public UpdatePasswordCommander (string email, string password, string newPassword, string newPasswordConfirm,MsSqlDataMapper ldm)
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

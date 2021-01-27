using AuctionHouseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    public class LoginCommander : ICommand
    {
        private string email;
        private string password;
        private MsSqlDataMapper ldm;
        public LoginCommander(string email, string password, MsSqlDataMapper ldm)
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

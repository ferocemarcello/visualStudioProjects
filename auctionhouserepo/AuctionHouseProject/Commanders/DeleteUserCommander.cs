using AuctionHouseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    public class DeleteUserCommander : ICommand
    {
        private string email;
        private MsSqlDataMapper ldm;

        

        public DeleteUserCommander(string email, MsSqlDataMapper ldm)
        {
            this.email = email;
            this.ldm = ldm;
        }

        public void Execute()
        {
            Helper.CheckEmailSyntax(email);
            Helper.Delete(email,ldm);
        }
    }
}

using AuctionHouseProject;
using System;

namespace AuctionHouseProject
{
    public class UpdateMailCommander : ICommand
    {
        private string email;
        private string newMail;
        private MsSqlDataMapper ldm;
        public UpdateMailCommander(string email, string newMail, MsSqlDataMapper ldm)
        {
            this.email = email;
            this.newMail = newMail;
            this.ldm = ldm;
        }

        public void Execute()
        {
            Helper.CheckEmailSyntax(newMail);
            Helper.ChangeEmail(email, newMail, ldm);
        }
    }
}
using System;

namespace Login_Component
{
    internal class ResetMailCommander : ICommand
    {
        private string email;
        private string newMail;
        private ILoginDataMapper ldm;
        public ResetMailCommander(string email, string newMail, ILoginDataMapper ldm)
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
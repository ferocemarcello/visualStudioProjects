using System;

namespace Login_Component
{
    internal class CreateUserCommand : ICommand
    {
        private string confirmPassword;
        private string email;
        private ILoginDataMapper ldm;
        private string password;

        public CreateUserCommand(string email, string password, string confirmPassword, ILoginDataMapper ldm)
        {
            this.email = email;
            this.password = password;
            this.confirmPassword = confirmPassword;
            this.ldm = ldm;
        }

        public void Execute()
        {
            Helper.CheckEmailSyntax(email);
            Helper.CheckPasswordSyntax(password);
            Helper.CheckPasswordEqual(password, confirmPassword);
            Helper.Store(email, Helper.GetEncryptedPassword(password),ldm);
        }
    }
}
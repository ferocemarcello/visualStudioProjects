using AuctionHouseProject;
using System;

namespace AuctionHouseProject
{
    public class CreateUserCommand : ICommand
    {
        private string confirmPassword;
        private string email;
        private MsSqlDataMapper ldm;
        private string password;
        private int balance;

        public CreateUserCommand(string email, string password, string confirmPassword,int balance, MsSqlDataMapper ldm)
        {
            this.email = email;
            this.password = password;
            this.confirmPassword = confirmPassword;
            this.ldm = ldm;
            this.balance = balance;
        }

        public void Execute()
        {
            Helper.CheckEmailSyntax(email);
            Helper.CheckPasswordSyntax(password);
            Helper.CheckPasswordEqual(password, confirmPassword);
            Helper.Store(email, Helper.GetEncryptedPassword(password),balance,ldm);
        }
    }
}
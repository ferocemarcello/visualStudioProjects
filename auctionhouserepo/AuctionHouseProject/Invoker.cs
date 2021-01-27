using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    public class Invoker//it should be the invoker
    {
        private MsSqlDataMapper ldm;

        public Invoker(MsSqlDataMapper ldm)
        {
            this.ldm = ldm;
        }
        public void CreateUser(User u)
        {
            ICommand c = new CreateUserCommand(u.getEmail(), u.getPassword(), u.getPassword(), u.getBalance(),ldm);
            c.Execute();
        }
        public void LoginUser(string email, string Password)
        {
            ICommand c = new LoginCommander(email, Password, ldm);
            c.Execute();
        }

        public void DeleteUser(string email)
        {
            ICommand c = new DeleteUserCommander(email,ldm);
            c.Execute();
        }

        public void UpdatePassword(string email, string password, string newPassword, string newConfirmPassword)
        {
            ICommand c = new UpdatePasswordCommander(email, password, newPassword, newConfirmPassword, ldm);
            c.Execute();
        }

        public void UpdateMail(string email, string newMail)
        {
            ICommand c = new UpdateMailCommander(email, newMail, ldm);
            c.Execute();
        }
        public void UpdateBalance(string email, int newBalance)
        {
            ICommand c = new UpdateBalanceCommander(email, newBalance, ldm);
            c.Execute();
        }
    }
}

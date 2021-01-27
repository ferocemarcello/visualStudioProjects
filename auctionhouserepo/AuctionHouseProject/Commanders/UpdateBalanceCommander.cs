using System;

namespace AuctionHouseProject
{
    public class UpdateBalanceCommander : ICommand
    {
        private string email;
        private MsSqlDataMapper ldm;
        private int newBalance;

        public UpdateBalanceCommander(string email, int newBalance, MsSqlDataMapper ldm)
        {
            this.email = email;
            this.newBalance = newBalance;
            this.ldm = ldm;
        }

        public void Execute()
        {
            ldm.UpdateBalance(email, newBalance);
        }
    }
}
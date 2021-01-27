using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    public class User
    {
        private string email;
        private string password;
        private int balance;

        public string ToStringCustom()
        {
            return this.email + this.password + this.balance.ToString();
        }
        public User(string email, string password, int balance)
        {
            this.email = email;
            this.password = password;
            this.balance = balance;
        }


        public string getEmail()
        {
            return this.email;
        }

        public string getPassword()
        {
            return this.password;
        }

        public int getBalance()
        {
            return this.balance;
        }



        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public void setBallance(int balance)
        {
            this.balance = balance;
        }
    }
}

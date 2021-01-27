using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyWebApplication.Models
{
    public class User
    {
        private string name;
        private string surname;
        private int age;

        public int GetAge()
        {
            return this.age;
        }
    }
}
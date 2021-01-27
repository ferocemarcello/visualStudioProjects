using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyWebApplication.Models
{
    [Serializable]
    public class ConversionType
    {
        public double amount;
        public string iso1;
        public string iso2;
        public ConversionType(double amount, string iso1, string iso2)
        {
            this.amount = amount;
            this.iso1 = iso1;
            this.iso2 = iso2;
        }
        public double GetAmount()
        {
            return this.amount;
        }
        public string GetIso1()
        {
            return this.iso1;
        }
        public string GetIso2()
        {
            return this.iso2;
        }
    }
}
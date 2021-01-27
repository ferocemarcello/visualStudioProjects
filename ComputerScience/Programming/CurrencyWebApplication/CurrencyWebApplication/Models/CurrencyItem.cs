using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyWebApplication.Models
{
    [Serializable]
    public class CurrencyItem
    {
        public string name;
        public string iso;
        public double exchange;
        public CurrencyItem(string name, string iso, double exchange)
         {
            this.name = name;
            this.iso = iso;
            this.exchange = exchange;
        }
        public string GetName()
        {
            return this.name;
        }
        public double GetExchange()
        {
            return this.exchange;
        }
        public string GetIso()
        {
            return this.iso;
        }

    }
}
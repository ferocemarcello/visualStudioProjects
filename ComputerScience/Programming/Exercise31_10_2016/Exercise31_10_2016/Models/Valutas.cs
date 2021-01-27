using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise31_10_2016.Models
{
    public class Valutas
    {
        private Dictionary<string, double> ExRatesISOs;
        [Required]
        public Valuta Valuta1 { get; set; }
        [Required]
        public Valuta Valuta2 { get; set; }
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public double ExchangedAmount { get; set; }
        public Valutas()
        {
            ExRatesISOs = new Dictionary<string, double>();
            ExRatesISOs.Add("USD", 0.147357);
            ExRatesISOs.Add("NOK", 1.21575665);
            ExRatesISOs.Add("GBP", 0.120650919);
            ExRatesISOs.Add("EUR", 0.134441844);
            ExRatesISOs.Add("SEK", 1.32944488);
            ExRatesISOs.Add("DKK", 1);
        }

        public void CalculateExchangedAmount(Valuta valuta1, Valuta valuta2, double amount)
        {
            double amountInDkk = amount / valuta1.ExRate;
            double amountInFinalValuta = amountInDkk * valuta2.ExRate;
            this.ExchangedAmount = amountInFinalValuta;
        }

        public double GetExRateFromISO(string ISO1)
        {
            Dictionary<string,double>.Enumerator en=ExRatesISOs.GetEnumerator();
            en.MoveNext();
            while (en.Current.Key != null)
            {
                if (en.Current.Key == ISO1)
                {
                    return en.Current.Value;
                }
                en.MoveNext();
            }
            return -1;
        }
    }
}
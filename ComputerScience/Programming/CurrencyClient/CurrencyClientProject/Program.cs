using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyServiceReference1.ICurrencyServer ics = new CurrencyServiceReference1.CurrencyServerClient();
            Console.WriteLine(ics.DkktoEuro(100)+"\n");

            Console.WriteLine("USD: " + ics.IsoToExchangeRate("USD"));
            Console.WriteLine("CAD: " + ics.IsoToExchangeRate("CAD"));
            Console.WriteLine("EUR: " + ics.IsoToExchangeRate("EUR"));
            Console.WriteLine("NOK: " + ics.IsoToExchangeRate("NOK"));
            Console.WriteLine("GBP: " + ics.IsoToExchangeRate("GBP"));
            Console.WriteLine("SEK: " + ics.IsoToExchangeRate("SEK")+"\n");
            
            foreach(CurrencyServiceReference1.CurrencyServerCurrencyItem i in ics.getCurrencyObjects())
            {
                Console.WriteLine(i.name + ", " + i.iso + ", " + i.exchange);
            }

            Console.WriteLine("1000 Norwegian Kroner equals to "+ics.ConvertFromIsoToIsoKeepSession("NOK", "GBP", 1000)+" Great Britain Pounds");
            Console.WriteLine("1000 Pounds equals to " + ics.ConvertFromIsoToIsoKeepSession("GBP", "EUR", 1000) + " euros");
            Console.WriteLine("1000 Norwegian Kroner equals to " + ics.ConvertFromIsoToIsoKeepSession("NOK", "USD", 1000) + " American dollars");
            Console.WriteLine("1000 Canadian dollars equals to " + ics.ConvertFromIsoToIsoKeepSession("CAD", "SEK", 1000) + " swedish kroner");

            foreach(CurrencyServiceReference1.ConversionType i in ics.allConversions())
            {
                Console.WriteLine("from " + i.iso1 + "to "+i.iso2 + " amount: " + i.amount + " dkk");
            }
            Console.WriteLine("number of conversions= " + ics.getNumberOfChanges());

            try
            {
                ics.ConvertFromIsoToIso("ASS", "USD", 12323);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            ics.CreateExchangeRate("ASS", 0.123456);
            ics.ConvertFromIsoToIso("ASS", "USD", 12323);
            Console.WriteLine("number of conversions= " + ics.getNumberOfChanges());
            Console.ReadLine();
        }
    }
}

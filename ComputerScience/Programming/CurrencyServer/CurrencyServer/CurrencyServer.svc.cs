using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Web;

namespace CurrencyServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CurrencyServer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CurrencyServer.svc or CurrencyServer.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CurrencyServer : ICurrencyServer
    {
        private Dictionary<string, double> rates = new Dictionary<string, double>();
        private LinkedList<CurrencyItem> ca = new LinkedList<CurrencyItem>();
        
        [DataContract]
        public class CurrencyItem
        {
            [DataMember]
            public string name;
            [DataMember]
            public string iso;
            [DataMember]
            public double exchange;
            public CurrencyItem(string name, string iso, double exchange)
            {
                this.name = name;
                this.iso = iso;
                this.exchange = exchange;
            }
        }
        public CurrencyServer()
        {
            
            rates.Add("USD", 0.15058);
            rates.Add("CAD", 0.197177086);
            rates.Add("EUR", 0.134172095);
            rates.Add("NOK", 1.21035287);
            rates.Add("GBP", 0.115612883);
            rates.Add("SEK", 1.2903834);
            ca.AddLast(new CurrencyItem("America", "USD", 6.66675556));
            ca.AddLast(new CurrencyItem("Canada", "CAD", 5.05996747));
            ca.AddLast(new CurrencyItem("Euro zone", "EUR", 7.43563248));
            ca.AddLast(new CurrencyItem("Norway", "NOK", 0.802897372));
            ca.AddLast(new CurrencyItem("Great Britain", "GBP", 8.6550154));
            ca.AddLast(new CurrencyItem("Sweden", "SEK", 0.775763677));
        }
        private double getElementByKey(string key)
        {
            Dictionary<string, double>.Enumerator en = rates.GetEnumerator();
            en.MoveNext();
            while (!en.Current.Key.Equals(key))
            {
                en.MoveNext();
            }
            return en.Current.Value;
        }
        public double DkktoEuro(double dkk)
        {
            return dkk / 7.43563248;
        }

        public void DoWork()
        {
        }

        public double IsoToExchangeRate(string iso)
        {
            return this.getElementByKey(iso);
        }
        public CurrencyItem[] getCurrencyObjects()
        {
            return this.ca.ToArray();
        }
        public double ConvertFromIsoToIso(string iso1, string iso2, double amount)
        {
            double ex1 = getElementByKey(iso1);
            double ex2= getElementByKey(iso2);
            double dkk = amount / ex1;
            double amount2 = ex2*dkk;
            return amount2;
        }
        public double ConvertFromIsoToIsoKeepSession(string iso1, string iso2, double amount)
        {
            double ex1 = getElementByKey(iso1);
            double ex2 = getElementByKey(iso2);
            double dkk = amount / ex1;
            double amount2 = ex2 * dkk;
            
            ConversionType ct = new ConversionType(dkk, iso1, iso2);
            LinkedList<ConversionType> lct = (LinkedList<ConversionType>)HttpContext.Current.Session["Conversions"];
            if (HttpContext.Current.Session["Conversions"] == null)
            {
                HttpContext.Current.Session["Counter"] = 0;
                lct=new LinkedList<ConversionType>();
                
            }
            int ex = ((int)HttpContext.Current.Session["Counter"]);
            lct.AddLast(ct);
            HttpContext.Current.Session["Conversions"] = lct;
            LinkedList<ConversionType> l = (LinkedList < ConversionType > )HttpContext.Current.Session["Conversions"];
            int count = ((int)(HttpContext.Current.Session["Counter"]));
            count++;
            HttpContext.Current.Session["Counter"] = count;
            ex = ((int)HttpContext.Current.Session["Counter"]);
            if (HttpContext.Current.Session["Conversions"] == null)
            {

            }
            return amount2;
        }
        public ConversionType[] allConversions()
        {
            return ((LinkedList<ConversionType>)HttpContext.Current.Session["Conversions"]).ToArray();
            
        }
        public void ChangeExchangeRate(string iso, double amount)
        {
            int i = 0;
            for (i = 0; i < rates.Count; i++)
            {
                if (rates.ElementAt(i).Key.Equals(iso))
                {
                    rates.Remove(iso);
                    rates.Add(iso, amount);
                }
            }
        }
        public void CreateExchangeRate(string iso, double amount)
        {
            if (rates.ContainsKey(iso))
            {
                throw new Exception();
            }
            rates.Add(iso, amount);
        }

        public int getNumberOfChanges()
        {
            return (int)HttpContext.Current.Session["Counter"];
        }
    }
}

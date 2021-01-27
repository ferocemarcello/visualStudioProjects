using CurrencyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Runtime.Serialization;
using System.IO;
namespace CurrencyWebApplication.Controllers
{
    public class CurrencyController : ApiController
    {
        public static Dictionary<string, double> rates = new Dictionary<string, double>();
        public static LinkedList<CurrencyItem> ca = new LinkedList<CurrencyItem>();

        public CurrencyController()
        {
            /*rates.Add("USD", 0.15058);
            rates.Add("CAD", 0.197177086);
            rates.Add("EUR", 0.134172095);
            rates.Add("NOK", 1.21035287);
            rates.Add("GBP", 0.115612883);
            rates.Add("SEK", 1.2903834);
            rates.Add("DKK", 1.0);*/
            

            try
            {
                getElementByKey("USD");
            }
            catch(Exception e)
            {
                rates.Add("USD", 0.15058);
                ca.AddLast(new CurrencyItem("America", "USD", 6.66675556));
            } 
            try
            {
                getElementByKey("CAD");
                
            }
            catch (Exception)
            {
                rates.Add("CAD", 0.197177086);
                ca.AddLast(new CurrencyItem("Canada", "CAD", 5.05996747));
            }
            try
            {
                getElementByKey("EUR");
            }
            catch (Exception)
            {
                rates.Add("EUR", 0.134172095);
                ca.AddLast(new CurrencyItem("Euro zone", "EUR", 7.43563248));
            }
            try
            {
                getElementByKey("NOK");
            }
            catch (Exception)
            {
                rates.Add("NOK", 1.21035287);
                ca.AddLast(new CurrencyItem("Norway", "NOK", 0.802897372));
            }
            try
            {
                getElementByKey("GBP");
            }
            catch (Exception)
            {
                rates.Add("GBP", 0.115612883);
                ca.AddLast(new CurrencyItem("Great Britain", "GBP", 8.6550154));
            }
            try
            {
                getElementByKey("SEK");
            }
            catch (Exception)
            {
                rates.Add("SEK", 1.2903834);
                ca.AddLast(new CurrencyItem("Sweden", "SEK", 0.775763677));
            }
            try
            {
                getElementByKey("DKK");
            }
            catch (Exception)
            {
                rates.Add("DKK", 1.0);
                ca.AddLast(new CurrencyItem("Denmark", "DKK", 1.0));
            }
            /*ca.AddLast(new CurrencyItem("America", "USD", 6.66675556));
            ca.AddLast(new CurrencyItem("Canada", "CAD", 5.05996747));
            ca.AddLast(new CurrencyItem("Euro zone", "EUR", 7.43563248));
            ca.AddLast(new CurrencyItem("Norway", "NOK", 0.802897372));
            ca.AddLast(new CurrencyItem("Great Britain", "GBP", 8.6550154));
            ca.AddLast(new CurrencyItem("Sweden", "SEK", 0.775763677));
            ca.AddLast(new CurrencyItem("Denmark", "DKK", 1.0));*/
        }
        [HttpGet]
        public double getElementByKey(string key)
        {
            Dictionary<string, double>.Enumerator en = rates.GetEnumerator();
            en.MoveNext();
            while (!en.Current.Key.Equals(key))
            {
                en.MoveNext();
            }
            return en.Current.Value;
        }
        private CurrencyItem getCurrencyByKey(string key)
        {
            LinkedList<CurrencyItem>.Enumerator en = ca.GetEnumerator();
            en.MoveNext();
            while (!en.Current.iso.Equals(key))
            {
                en.MoveNext();
            }
            return en.Current;
        }
        [HttpGet]
        [ActionName("DkktoEuro")]
        public double DkktoEuro(double dkk)
        {
            return dkk / 7.43563248;
        }
        [HttpGet]
        
        public double IsoToExchangeRate(string iso)
        {
            return this.getElementByKey(iso);
        }
        [HttpGet]
        //[ActionName("getCurrencyObjects")]
        public CurrencyItem[] getCurrencyObjects()
        { 
            return ca.ToArray();
        }
        [HttpGet]
        public double ConvertFromIsoToIso(string iso1, string iso2, double amount)
        {
            double ex1 = getElementByKey(iso1);
            double ex2 = getElementByKey(iso2);
            double dkk = amount / ex1;
            double amount2 = ex2 * dkk;
            return amount2;
        }
        [HttpGet]
        public bool ChangeExchangeRate(string iso, double amount)
        {
            int i = 0;
            for (i = 0; i < rates.Count; i++)
            {
                if (rates.ElementAt(i).Key.Equals(iso))
                {
                    rates.Remove(iso);
                    rates.Add(iso, amount);
                    CurrencyItem ci = getCurrencyByKey(iso);
                    ca.Remove(ci);
                    ci.exchange = amount;
                    ca.AddLast(ci);
                    return true;
                }
            }
            return false;
        }
        [HttpGet]
        public bool CreateExchangeRate(string iso, double amount,string name)
        {
            CurrencyItem ci = new CurrencyItem(name, iso, amount);
            if (rates.ContainsKey(iso)||ca.Contains(ci))
            {
                throw new Exception();
            }
            rates.Add(iso, amount);
            ca.AddLast(ci);
            return true;
        }
        [HttpGet]
        public void writeTest(string prova)
        {
            System.IO.File.AppendAllText(@"C:\Users\feroc\Downloads\Message.txt", prova + Environment.NewLine);
        }
        [HttpGet]
        //[ActionName("ConvertFromIsoToIsoKeepSession")]
        public double ConvertFromIsoToIsoKeepSession(string iso1, string iso2, double amount)
        {
            
            double ex1 = getElementByKey(iso1);
            double ex2 = getElementByKey(iso2);
            double dkk = amount / ex1;
            double amount2 = ex2 * dkk;
            var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;
            ConversionType ct = new ConversionType(dkk, iso1, iso2);
            httpContext.Application.Lock();
            LinkedList<ConversionType> lct = (LinkedList<ConversionType>)HttpContext.Current.Session["Conversions"];
            if (httpContext.Session["Conversions"] == null)
            {
                httpContext.Session["Counter"] = 0;
                lct = new LinkedList<ConversionType>();
            }
            int ex = ((int)httpContext.Session["Counter"]);
            lct.AddLast(ct);
            httpContext.Session["Conversions"] = lct;
            LinkedList<ConversionType> l = (LinkedList<ConversionType>)httpContext.Session["Conversions"];
            int count = ((int)(httpContext.Session["Counter"]));
            count++;
            httpContext.Session["Counter"] = count;
            ex = ((int)httpContext.Session["Counter"]);
            httpContext.Application.UnLock();
            return amount2;
        }
        [HttpGet]
        [ActionName("GetAllConversions")]
        public ConversionType[] allConversions()
        {
            var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;
            httpContext.Application.Lock();

            if (httpContext.Session["Conversions"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            ConversionType[] ci= ((LinkedList<ConversionType>)httpContext.Session["Conversions"]).ToArray();
            httpContext.Application.UnLock();
            return ci;
        }
    }
}

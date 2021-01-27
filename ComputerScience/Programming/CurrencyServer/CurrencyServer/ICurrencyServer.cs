using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static CurrencyServer.CurrencyServer;


namespace CurrencyServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICurrencyServer" in both code and config file together.
    
    [ServiceContract]
    public interface ICurrencyServer
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        double DkktoEuro(double dkk);
        [OperationContract]
        double IsoToExchangeRate(string iso);
        [OperationContract]
        CurrencyItem[] getCurrencyObjects();
        [OperationContract]
        double ConvertFromIsoToIso(string iso1, string iso2, double amount);
        [OperationContract]
        void ChangeExchangeRate(string iso, double amount);
        [OperationContract]
        void CreateExchangeRate(string iso, double amount);
        [OperationContract]
        double ConvertFromIsoToIsoKeepSession(string iso1, string iso2, double amount);
        [OperationContract]
        ConversionType[] allConversions();
        [OperationContract]
        int getNumberOfChanges();



    }
}

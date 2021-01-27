using System.Runtime.Serialization;

namespace CurrencyServer
{
    [DataContract]
    public class ConversionType
    {
        [DataMember]
        public double amount;
        [DataMember]
        public string iso1;
        [DataMember]
        public string iso2;
        public ConversionType(double amount,string iso1, string iso2)
        {
            this.amount = amount;
            this.iso1 = iso1;
            this.iso2 = iso2;
        }
    }
}
using System.Runtime.Serialization;

namespace GoToMarket.CieloConnector
{
    [DataContract]
    public class CieloPaymentRequest
    {

        [DataMember(Name = "MerchantOrderId")]
        public string MerchantOrderId { get; set; }

        [DataMember(Name = "Customer")]
        public Customer CustomerObj { get; set; }

        [DataMember(Name = "Payment")]
        public Payment PaymentObj { get; set; }

        [DataContract]
        public class Customer
        {

            [DataMember(Name = "Name")]
            public string Name { get; set; }
        }

        [DataContract]
        public class CreditCard
        {

            [DataMember(Name = "CardNumber")]
            public string CardNumber { get; set; }

            [DataMember(Name = "Holder")]
            public string Holder { get; set; }

            [DataMember(Name = "ExpirationDate")]
            public string ExpirationDate { get; set; }

            [DataMember(Name = "SecurityCode")]
            public string SecurityCode { get; set; }

            [DataMember(Name = "Brand")]
            public string Brand { get; set; }
        }

        [DataContract]
        public class Payment
        {

            [DataMember(Name = "Type")]
            public string Type { get; set; }

            [DataMember(Name = "Capture")]
            public bool Capture { get; set; }

            [DataMember(Name = "Amount")]
            public long Amount { get; set; }

            [DataMember(Name = "Installments")]
            public long Installments { get; set; }

            [DataMember(Name = "CreditCard")]
            public CreditCard CreditCard { get; set; }
        }
    }
}

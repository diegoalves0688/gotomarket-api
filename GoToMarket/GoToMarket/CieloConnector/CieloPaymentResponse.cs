using System.Runtime.Serialization;

namespace GoToMarket.CieloConnector
{
    [DataContract]
    public class CieloPaymentResponse
    {

        [DataMember(Name = "MerchantOrderId")]
        public string MerchantOrderId { get; set; }

        [DataMember(Name = "Payment")]
        public Payment PaymentObj { get; set; }

        [DataContract]
        public class Payment
        {

            [DataMember(Name = "Tid")]
            public string Tid { get; set; }

            [DataMember(Name = "Amount")]
            public int Amount { get; set; }

            [DataMember(Name = "ReceivedDate")]
            public string ReceivedDate { get; set; }

            [DataMember(Name = "Status")]
            public int Status { get; set; }

            [DataMember(Name = "ReturnMessage")]
            public string ReturnMessage { get; set; }

            [DataMember(Name = "ReturnCode")]
            public string ReturnCode { get; set; }

            [DataMember(Name = "PaymentId")]
            public string PaymentId { get; set; }
        }
    }

    

}

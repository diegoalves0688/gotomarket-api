﻿using System;
using System.Runtime.Serialization;

namespace GoToMarket
{
    [DataContract]
    public class Order
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "date")]
        public DateTime? Date  { get; set; }

        [DataMember(Name = "value")]
        public long Value { get; set; }

        [DataMember(Name = "productName")]
        public string ProductName { get; set; }

        [DataMember(Name = "ownerId")]
        public long OwnerId { get; set; }

        [DataMember(Name = "buyerId")]
        public long BuyerId { get; set; }

        [DataMember(Name = "cardNumber")]
        public string CardNumber { get; set; }

        [DataMember(Name = "expirationDate")]
        public string ExpirationDate { get; set; }

        [DataMember(Name = "securityCode")]
        public string SecurityCode { get; set; }
    }
}
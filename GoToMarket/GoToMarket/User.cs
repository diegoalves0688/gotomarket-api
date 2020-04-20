using System.Runtime.Serialization;

namespace GoToMarket
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "payment_id")]
        public string Payment_id { get; set; }

        [DataMember(Name = "payment_key")]
        public string Payment_key { get; set; }
    }
}

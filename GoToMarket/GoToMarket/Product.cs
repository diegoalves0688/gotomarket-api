using System.Runtime.Serialization;

namespace GoToMarket
{
    [DataContract]
    public class Product
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "imageUrl")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "price")]
        public long Price { get; set; }

        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "ownerId")]
        public string OwnerId { get; set; }
    }
}

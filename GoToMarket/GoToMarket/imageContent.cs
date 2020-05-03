using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GoToMarket
{
    [DataContract]
    public class ImageContent
    {

        [DataMember(Name = "image")]
        public string Image { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}

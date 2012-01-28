using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
    {
        large: "http://a3.twimg.com/profile_images/1403659812/g1.jpg",
        small: "http://a3.twimg.com/profile_images/1403659812/g1_normal.jpg"
    }
    */
    [DataContract]
    public class Avatar
    {
        [DataMember(Name = "small")]
        public Uri Small { get; set; }

        [DataMember(Name = "large")]
        public Uri Large { get; set; }
    }
}

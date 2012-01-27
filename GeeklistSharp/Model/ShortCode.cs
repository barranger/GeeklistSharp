using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
        short_code: {
            gklst_url: "http://gkl.st/XuQdJ",
            id: "32002d0dea77d1e55dcdb17b93456b789f0726b659e2d605bd6047db6c046865"
        }
    */
    [DataContract]
    public class ShortCode
    {
        [DataMember(Name = "gklst_url")]
        public string GklstUrl { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}

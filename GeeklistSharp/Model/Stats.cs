using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{

    [DataContract]
    public class Stats
    {
        [DataMember(Name = "number_of_contributions")]
        public long Contributions { get; set; }

        //TODO: Bring up the fact that User->Status has number_of_highfives while Card->Status has just highfives.
        [DataMember(Name = "number_of_highfives")]
        public long NumberOfHighFives { get; set; }

        [DataMember(Name = "highfives")]
        public long HighFives { get; set; }

        [DataMember(Name = "number_of_mentions")]
        public long Mentions { get; set; }

        [DataMember(Name = "number_of_cards")]
        public long Cards { get; set; }

        [DataMember(Name = "number_of_pings")]
        public long Pings { get; set; }

        [DataMember(Name = "views")]
        public int Views { get; set; }
    }
}

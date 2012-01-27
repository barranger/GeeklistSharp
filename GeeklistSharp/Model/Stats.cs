using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
        stats: {
            number_of_views: 55,
            views: 64,
            highfives: 3
        }
    */
    [DataContract]
    public class Stats
    {
        //[DataMember(Name = "number_of_views")]
        //public string NumberOfViews { get; set; }

        [DataMember(Name = "highfives")]
        public int HighFives { get; set; }

        [DataMember(Name = "views")]
        public int Views { get; set; }
    }
}

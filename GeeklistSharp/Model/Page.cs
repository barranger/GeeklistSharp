using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GeeklistSharp.Model
{
    [DataContract]
    public class Page
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}

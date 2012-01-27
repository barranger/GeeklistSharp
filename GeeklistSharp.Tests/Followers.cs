using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeeklistSharp.Model;
using System.Runtime.Serialization;

namespace GeeklistSharp.Tests
{
    [DataContract]
    public class FollowersData
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "followers")]
        public List<User> Followers { get; set; }
    }
}

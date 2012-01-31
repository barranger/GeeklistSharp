using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeeklistSharp.Model;
using System.Runtime.Serialization;

namespace GeeklistSharp.Model
{
    [DataContract]
    public class FollowersData : Page
    {
        [DataMember(Name = "total_followers")]
        public int TotalFollowers { get; set; }

        [DataMember(Name = "followers")]
        public User[] Followers { get; set; }
    }

    [DataContract]
    public class FollowingData : Page
    {
        [DataMember(Name = "total_following")]
        public int TotalFollowing { get; set; }

        [DataMember(Name = "following")]
        public User[] Following { get; set; }
    }
}

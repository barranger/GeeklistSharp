using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
        {
            user: {
                avatar: {
                    small: "http://a2.twimg.com/profile_images/1690395138/mesmal_normal.jpg",
                    large: "http://a2.twimg.com/profile_images/1690395138/mesmal.jpg"
                },
                screen_name: "MacDaddy",
                id: "a50c2d6c4a12acf135f732cb85352a53749620e157c1d7ba8a3cec45f5ca19ec"
            },
            gfk: {
                mentions: [ ],
                hashtags: [ ],
                details: [ ],
                avatar: {
                    large: "http://a3.twimg.com/profile_images/1403659812/g1.jpg",
                    small: "http://a3.twimg.com/profile_images/1403659812/g1_normal.jpg"
                },
                id: "6f02309648a0a8ca4e794e5a50a5bf94e22c1444ccda91848aa219cf77d49ca0",
                screen_name: "gemmarrose"
            },
            created_at: "2011-12-15T23:56:03.756Z",
            updated_at: "2011-12-15T23:56:03.777Z",
            type: "follow",
            id: "e14c252862bc67722f5ccf1a957472567cb41b5e51c9eea4636c6efc00ce304a"
        }
    */
    [DataContract]
    public class Activity
    {
        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "gfk")]
        public Gfk Gfk { get; set; }

        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}

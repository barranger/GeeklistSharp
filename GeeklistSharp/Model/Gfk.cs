using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
    {
        mentions: [ ],
        hashtags: [ ],
        details: [ ],
        avatar: {
            large: "http://a3.twimg.com/profile_images/1403659812/g1.jpg",
            small: "http://a3.twimg.com/profile_images/1403659812/g1_normal.jpg"
        },
        id: "6f02309648a0a8ca4e794e5a50a5bf94e22c1444ccda91848aa219cf77d49ca0",
        screen_name: "gemmarrose"
    }
    */
    [DataContract]
    public class Gfk
    {
        [DataMember(Name = "mentions")]
        public List<string> Mentions { get; set; }

        [DataMember(Name = "hashtags")]
        public List<string> Hashtags { get; set; }

        [DataMember(Name = "details")]
        public List<string> Details { get; set; }

        [DataMember(Name = "avatar")]
        public Avatar Avatar { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }
    }
}

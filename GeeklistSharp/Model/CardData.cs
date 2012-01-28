using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
        "total_cards": 1,
        "cards": [
            {
                author_id: "a271659310088dc1a09fe0af9ddf6dd2d1987ddb99d2ca23af50a7fae55256d9",
                created_at: "2011-09-14T04:46:30.384Z",
                happened_at: "2011-09-06T00:00:00.000Z",
                happened_at_type: "custom",
                headline: "I placed 23rd out of >180 at Nodeknockout 2011",
                is_active: true,
                permalink: "/chapel/i-placed-23rd-out-of-180-at-nodeknockout-2011",
                slug: "i-placed-23rd-out-of-180-at-nodeknockout-2011",
                tasks: [ ],
                updated_at: "2011-11-28T23:05:42.180Z",
                stats: {
                    number_of_views: 55,
                    views: 64,
                    highfives: 3
                },
                short_code: {
                    gklst_url: "http://gkl.st/XuQdJ",
                    id: "32002d0dea77d1e55dcdb17b93456b789f0726b659e2d605bd6047db6c046865"
                },
                id: "32002d0dea77d1e55dcdb17b93456b7807b3c1b0695e177228f4fa12f227119b"
            }
        ]
     */
    [DataContract]
    public class CardData
    {
        [DataMember(Name = "total_cards")]
        public int TotalCards { get; set; }

        [DataMember(Name = "cards")]
        public List<Card> Cards { get; set; }
    }
}

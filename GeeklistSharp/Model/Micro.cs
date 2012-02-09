using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
        "total_micros": 1,
        "micros": 
        [
            {
                "created_at": "2011-09-20T05:59:21.251Z",
                "permalink": "/chapel/micro/165",
                "slug": "165",
                "status": "Now you can't get people too drunk. Else you have to drive them home! @gklst",
                "updated_at": "2011-09-20T05:59:21.262Z",
                "mentions": [
                    "5ac464b28beb8240d32a4b66c45ec0d9cbb147b7e7df3ba74b48bd0d70894e60"
                ],
                "reply": {
                    "thread": {
                        "id": "707a098e2f345b76392eea59084e2d21f05b5cb1ab0ca602540e6efd3bfe7356",
                        "status": "Now you can't get people too drunk. Else you have to drive them home! @gklst",
                        "permalink": "/chapel/micro/165",
                        "type": "micro"
                    },
                    "in_reply_to": {
                        "id": "707a098e2f345b76392eea59084e2d21f05b5cb1ab0ca602540e6efd3bfe7356",
                        "status": "Now you can't get people too drunk. Else you have to drive them home! @gklst",
                        "permalink": "/chapel/micro/165",
                        "type": "micro"
                    }
                },
                "short_code": {
                    "gklst_url": "http://gkl.st/XttuO",
                    "id": "707a098e2f345b76392eea59084e2d219da9ecc67b0599565680cee12b424544"
                },
                "user": {
                    "avatar": {
                            "small": "http://a1.twimg.com/profile_images/1340947562/me_badass_ava_normal.png",
                            "large": "http://a1.twimg.com/profile_images/1340947562/me_badass_ava.png"
                    },
                    "screen_name": "chapel",
                    "id": "a271659310088dc1a09fe0af9ddf6dd2d1987ddb99d2ca23af50a7fae55256d9"
                },
                "id": "707a098e2f345b76392eea59084e2d21f05b5cb1ab0ca602540e6efd3bfe7356",
                "has_highfived": false,
                "is_author": true
            }
        ]
    */
    [DataContract]
    public class Micro
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "permalink")]
        public string Permalink { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DataMember(Name = "mentions")]
        public List<string> Mentions { get; set; }

        [DataMember(Name = "reply")]
        public Reply Reply { get; set; }

        [DataMember(Name = "shrt_code")]
        public ShortCode ShortCode { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "has_highfived")]
        public bool HasHighFived { get; set; }

        [DataMember(Name = "is_author")]
        public bool IsAuthor { get; set; }
    }
}

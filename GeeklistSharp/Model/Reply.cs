using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GeeklistSharp.Model
{
    /*
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
        }
    */
    [DataContract]
    public class Reply
    {
        [DataMember(Name = "thread")]
        public ReplyPart Thread { get; set; }

        [DataMember(Name = "in_reply_to")]
        public ReplyPart InReplyTo { get; set; }
    }

    [DataContract]
    public class ReplyPart
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "permalink")]
        public string Permalink { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

}

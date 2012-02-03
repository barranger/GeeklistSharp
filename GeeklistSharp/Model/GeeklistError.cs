using System.Runtime.Serialization;

namespace GeeklistSharp.Model
{
    [DataContract]
    public class GeeklistError
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "error")]
        public string Message { get; set; }
    }
}
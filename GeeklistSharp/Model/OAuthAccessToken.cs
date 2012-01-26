using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeeklistSharp.Model
{
    public class OAuthAccessToken
    {
        public virtual string Token { get; set; }
        public virtual string TokenSecret { get; set; }
    }
}

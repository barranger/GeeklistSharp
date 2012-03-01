
﻿using System;
using System.Collections.Generic;
﻿using System.IO;
﻿using System.Linq;
using System.Text;

namespace GeeklistSharp.Tests
{
    public class TestConstants
    {

#warning Add Your Geekli.st Keys here
        public const string OAUTH_CONSUMER_KEY = "";
        public const string OAUTH_CONSUMER_SECRET = "";
        public const string TOKEN = "";
        public const string TOKEN_SECRET = ""; 
        public const string CARDID = "";
        public const string MICROID = "";
        public const string USERID = "";
        public const string USERNAME = "";

        public static readonly Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

        public static T DeserializeFromStream<T>(string testJsonData)
        {
            MemoryStream memoryStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(testJsonData));

            return DeserializeFromStream<T>(memoryStream);
        }

        private static T DeserializeFromStream<T>(System.IO.Stream jsonStream)
        {
            // code should match GeekListService.GetResponse<T>(Stream stream), other than
            // returning T instead of Response<T>
            var streamReader = new StreamReader(jsonStream);

            var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader);

            var result = serializer.Deserialize<T>(jsonTextReader);

            return result;
        }
    }
}


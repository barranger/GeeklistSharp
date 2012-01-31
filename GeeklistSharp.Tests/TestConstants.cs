
﻿using System;
using System.Collections.Generic;
﻿using System.IO;
﻿using System.Linq;
using System.Text;

namespace GeeklistSharp.Tests
{
    public class TestConstants
    {

//#error Add Your Geekli.st Keys here
        public const string OAUTH_CONSUMER_KEY = "WRP0IToyEfSym6WjALL_ryfA18s";
        public const string OAUTH_CONSUMER_SECRET = "HDOiP47DT4S7axLc2ai2Zv4UVGNXXerh6yNcdRNSBno";
        public const string TOKEN = "UVytN56pN9260cqG6AmAGm_v-wE";
        public const string TOKEN_SECRET = "ZT0IQJxySPfr-HNgbbDinsFUCwHDANsgxyK7LQeVavU";
        public const string CARDID = "146a1bcbe95def14a19a5441cbccb17f5b7b06b25b99396ac906872e584b268a";
        
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeeklistSharp.Tests
{
    public class TestConstants
    {
//#error Add Your Geekli.st Keys here
        public const string OAUTH_CONSUMER_KEY = "hK2AQu3c-8r7FTf4xofwcNSulPQ";
        public const string OAUTH_CONSUMER_SECRET = "APs6SeRKbfDKt8ajVKUs1vELM2YIeC1TCdyrvKvkziI";
        public const string TOKEN = "EoJpBVADjfUrKcY5ZjckIOP0UM0";
        public const string TOKEN_SECRET = "ZpwhXxN90HLq_EzclBZbY8kM4ck32ZhZV-Y1-Joorv4";

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

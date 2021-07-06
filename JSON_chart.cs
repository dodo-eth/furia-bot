using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace dex_dotnet_bot
{
    class JSON_chart
    {// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Root
        {
            [JsonProperty("o")]
            public List<double> O { get; set; }

            [JsonProperty("c")]
            public List<double> C { get; set; }

            [JsonProperty("h")]
            public List<double> H { get; set; }

            [JsonProperty("l")]
            public List<double> L { get; set; }

            [JsonProperty("v")]
            public List<double> V { get; set; }

            [JsonProperty("t")]
            public List<int> T { get; set; }

            [JsonProperty("s")]
            public string S { get; set; }

            [JsonProperty("price_scale")]
            public long PriceScale { get; set; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace dex_dotnet_bot
{
    class info_json
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Root
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("txns24h")]
            public int Txns24h { get; set; }

            [JsonProperty("txns24hChange")]
            public double Txns24hChange { get; set; }

            [JsonProperty("verified")]
            public bool Verified { get; set; }

            [JsonProperty("decimals")]
            public int Decimals { get; set; }

            [JsonProperty("volume24h")]
            public double Volume24h { get; set; }

            [JsonProperty("volume24hUSD")]
            public double Volume24hUSD { get; set; }

            [JsonProperty("volume24hETH")]
            public double Volume24hETH { get; set; }

            [JsonProperty("volumeChange24h")]
            public double VolumeChange24h { get; set; }

            [JsonProperty("liquidityUSD")]
            public double LiquidityUSD { get; set; }

            [JsonProperty("liquidityETH")]
            public double LiquidityETH { get; set; }

            [JsonProperty("liquidityChange24h")]
            public double LiquidityChange24h { get; set; }

            [JsonProperty("logoURI")]
            public object LogoURI { get; set; }

            [JsonProperty("priceUSD")]
            public double PriceUSD { get; set; }

            [JsonProperty("priceETH")]
            public double PriceETH { get; set; }

            [JsonProperty("priceChange24h")]
            public double PriceChange24h { get; set; }

            [JsonProperty("priceUSDChange24h")]
            public double PriceUSDChange24h { get; set; }

            [JsonProperty("priceETHChange24h")]
            public double PriceETHChange24h { get; set; }

            [JsonProperty("timestamp")]
            public int Timestamp { get; set; }

            [JsonProperty("blockNumber")]
            public int BlockNumber { get; set; }

            [JsonProperty("AMM")]
            public string AMM { get; set; }

            [JsonProperty("network")]
            public string Network { get; set; }
        }


    }
}

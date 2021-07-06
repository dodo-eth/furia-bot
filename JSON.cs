using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace dex_dotnet_bot
{
    class JSON
    {
        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("transactionAddress")]
            public string TransactionAddress { get; set; }

            [JsonProperty("timestamp")]
            public int Timestamp { get; set; }

            [JsonProperty("blockNumber")]
            public int BlockNumber { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("sender")]
            public string Sender { get; set; }

            [JsonProperty("amountUSD")]
            public double AmountUSD { get; set; }

            [JsonProperty("amountETH")]
            public double AmountETH { get; set; }

            [JsonProperty("amount0In")]
            public double Amount0In { get; set; }

            [JsonProperty("amount0Out")]
            public double Amount0Out { get; set; }

            [JsonProperty("amount1Out")]
            public double Amount1Out { get; set; }

            [JsonProperty("amount1In")]
            public double Amount1In { get; set; }

            [JsonProperty("pairAddress")]
            public string PairAddress { get; set; }

            [JsonProperty("pairLiquidityUSD")]
            public double PairLiquidityUSD { get; set; }

            [JsonProperty("pairLiquidityETH")]
            public double PairLiquidityETH { get; set; }

            [JsonProperty("token0Address")]
            public string Token0Address { get; set; }

            [JsonProperty("token1Address")]
            public string Token1Address { get; set; }

            [JsonProperty("token0Symbol")]
            public string Token0Symbol { get; set; }

            [JsonProperty("token1Symbol")]
            public string Token1Symbol { get; set; }

            [JsonProperty("token0PriceUSD")]
            public double Token0PriceUSD { get; set; }

            [JsonProperty("token1PriceUSD")]
            public double Token1PriceUSD { get; set; }

            [JsonProperty("token0PriceETH")]
            public double Token0PriceETH { get; set; }

            [JsonProperty("token1PriceETH")]
            public double Token1PriceETH { get; set; }

            [JsonProperty("walletAddress")]
            public string WalletAddress { get; set; }

            [JsonProperty("walletCategory")]
            public string WalletCategory { get; set; }

            [JsonProperty("AMM")]
            public string AMM { get; set; }

            [JsonProperty("network")]
            public string Network { get; set; }
        }

        public class Root
        {
            [JsonProperty("total")]
            public object Total { get; set; }

            [JsonProperty("took")]
            public double Took { get; set; }

            [JsonProperty("data")]
            public List<Datum> Data { get; set; }
        }

    }
}

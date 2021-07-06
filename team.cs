using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dex_dotnet_bot
{
    class team
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Event
        {
            [JsonProperty("network")]
            public string Network { get; set; }

            [JsonProperty("chainId")]
            public string ChainId { get; set; }

            [JsonProperty("isWithdrawn")]
            public bool IsWithdrawn { get; set; }

            [JsonProperty("lockContractAddress")]
            public string LockContractAddress { get; set; }

            [JsonProperty("lockAmount")]
            public double LockAmount { get; set; }

            [JsonProperty("lockDepositId")]
            public int LockDepositId { get; set; }

            [JsonProperty("unlockTime")]
            public int UnlockTime { get; set; }

            [JsonProperty("withdrawalAddress")]
            public string WithdrawalAddress { get; set; }

            [JsonProperty("tokenAddress")]
            public string TokenAddress { get; set; }

            [JsonProperty("tokenTotalSupply")]
            public double TokenTotalSupply { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("senderAddress")]
            public string SenderAddress { get; set; }

            [JsonProperty("timeStamp")]
            public int TimeStamp { get; set; }

            [JsonProperty("transactionAmount")]
            public double TransactionAmount { get; set; }

            [JsonProperty("transactionHash")]
            public string TransactionHash { get; set; }

            [JsonProperty("transactionIndex")]
            public int TransactionIndex { get; set; }

            [JsonProperty("liquidityContractAddress")]
            public string LiquidityContractAddress { get; set; }

            [JsonProperty("liquidityPairAddress")]
            public string LiquidityPairAddress { get; set; }

            [JsonProperty("liquidityTotalSupply")]
            public double? LiquidityTotalSupply { get; set; }

            [JsonProperty("liquidityPairReserve")]
            public string LiquidityPairReserve { get; set; }

            [JsonProperty("liquidityTokenReserve")]
            public double? LiquidityTokenReserve { get; set; }
        }

        public class Token
        {
            [JsonProperty("network")]
            public string Network { get; set; }

            [JsonProperty("chainId")]
            public string ChainId { get; set; }

            [JsonProperty("isLiquidityToken")]
            public bool IsLiquidityToken { get; set; }

            [JsonProperty("tokenDecimals")]
            public int TokenDecimals { get; set; }

            [JsonProperty("tokenName")]
            public string TokenName { get; set; }

            [JsonProperty("tokenSymbol")]
            public string TokenSymbol { get; set; }

            [JsonProperty("tokenTotalSupply")]
            public double TokenTotalSupply { get; set; }

            [JsonProperty("tokenAddress")]
            public string TokenAddress { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("liquidityLockedInPercent")]
            public double LiquidityLockedInPercent { get; set; }

            [JsonProperty("liquidityLockedInUsd")]
            public double LiquidityLockedInUsd { get; set; }

            [JsonProperty("tokenCirculatingSupply")]
            public object TokenCirculatingSupply { get; set; }

            [JsonProperty("tokenLocked")]
            public object TokenLocked { get; set; }
        }

        public class LiquidityContract
        {
            [JsonProperty("network")]
            public string Network { get; set; }

            [JsonProperty("chainId")]
            public string ChainId { get; set; }

            [JsonProperty("isLiquidityToken")]
            public bool IsLiquidityToken { get; set; }

            [JsonProperty("tokenAddress")]
            public string TokenAddress { get; set; }

            [JsonProperty("tokenDecimals")]
            public int TokenDecimals { get; set; }

            [JsonProperty("tokenName")]
            public string TokenName { get; set; }

            [JsonProperty("tokenSymbol")]
            public string TokenSymbol { get; set; }

            [JsonProperty("tokenTotalSupply")]
            public double TokenTotalSupply { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }
        }

        public class Pair
        {
            [JsonProperty("network")]
            public string Network { get; set; }

            [JsonProperty("chainId")]
            public string ChainId { get; set; }

            [JsonProperty("isLiquidityToken")]
            public bool IsLiquidityToken { get; set; }

            [JsonProperty("tokenDecimals")]
            public int TokenDecimals { get; set; }

            [JsonProperty("tokenName")]
            public string TokenName { get; set; }

            [JsonProperty("tokenSymbol")]
            public string TokenSymbol { get; set; }

            [JsonProperty("tokenTotalSupply")]
            public double TokenTotalSupply { get; set; }

            [JsonProperty("tokenAddress")]
            public string TokenAddress { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("tokenImage")]
            public string TokenImage { get; set; }

            [JsonProperty("tokenPrice")]
            public double TokenPrice { get; set; }

            [JsonProperty("liquidityLockedInPercent")]
            public double LiquidityLockedInPercent { get; set; }

            [JsonProperty("liquidityLockedInUsd")]
            public double LiquidityLockedInUsd { get; set; }

            [JsonProperty("tokenCirculatingSupply")]
            public double TokenCirculatingSupply { get; set; }

            [JsonProperty("tokenLocked")]
            public double TokenLocked { get; set; }

            [JsonProperty("tokenLockedInUsd")]
            public double TokenLockedInUsd { get; set; }
        }

        public class Datum
        {
            [JsonProperty("event")]
            public Event Event { get; set; }

            [JsonProperty("token")]
            public Token Token { get; set; }

            [JsonProperty("liquidityContract")]
            public LiquidityContract LiquidityContract { get; set; }

            [JsonProperty("pair")]
            public Pair Pair { get; set; }
        }

        public class Root
        {
            [JsonProperty("data")]
            public List<Datum> Data { get; set; }
        }


    }
}

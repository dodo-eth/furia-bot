using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace dex_dotnet_bot
{
    class holders
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Item
        {
            [JsonProperty("contract_decimals")]
            public int ContractDecimals { get; set; }

            [JsonProperty("contract_name")]
            public string ContractName { get; set; }

            [JsonProperty("contract_ticker_symbol")]
            public string ContractTickerSymbol { get; set; }

            [JsonProperty("contract_address")]
            public string ContractAddress { get; set; }

            [JsonProperty("supports_erc")]
            public object SupportsErc { get; set; }

            [JsonProperty("logo_url")]
            public string LogoUrl { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("balance")]
            public string Balance { get; set; }

            [JsonProperty("total_supply")]
            public string TotalSupply { get; set; }

            [JsonProperty("block_height")]
            public int BlockHeight { get; set; }
        }

        public class Pagination
        {
            [JsonProperty("has_more")]
            public bool HasMore { get; set; }

            [JsonProperty("page_number")]
            public int PageNumber { get; set; }

            [JsonProperty("page_size")]
            public int PageSize { get; set; }

            [JsonProperty("total_count")]
            public int TotalCount { get; set; }
        }

        public class Data
        {
            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }

            [JsonProperty("items")]
            public List<Item> Items { get; set; }

            [JsonProperty("pagination")]
            public Pagination Pagination { get; set; }
        }

        public class Root
        {
            [JsonProperty("data")]
            public Data Data { get; set; }

            [JsonProperty("error")]
            public bool Error { get; set; }

            [JsonProperty("error_message")]
            public object ErrorMessage { get; set; }

            [JsonProperty("error_code")]
            public object ErrorCode { get; set; }
        }


    }
}

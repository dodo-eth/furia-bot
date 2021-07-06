using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using ScottPlot;
using ScottPlot.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Globalization;
using System.Timers;
using System.Globalization;
namespace dex_dotnet_bot
{
    class Program
    {
       
         
        private static System.Timers.Timer aTimer;

        static TelegramBotClient Bot;
        static TelegramBotClient Bot_oru;
        static string one_furia_usdt  ;
        static List<string> trx_list = new List<string>();
        static List<string> tx_Hash = new List<string>();
        static string url_team_coins = "https://team.finance/view-coin/0x8500c4a12Ce0ea7B16C3E8c959eCF7837FBaF93F?name=FURIA.Finance&symbol=FURIA";
        static string burn_furia_url = "https://bscscan.com/token/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f?a=0x000000000000000000000000000000000000dead";
        static string holder_url = "https://api.covalenthq.com/v1/56/tokens/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f/token_holders/?&key=ckey_2b419cf4f8f4426b89f2ae0b3e7";
        static string graph_url = "https://poocoin.app/tokens/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f";
        static string tx_hash_proverka = null;
        static string json_proverka = null;
        static string usrl_contract = "https://bscscan.com/address/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f";
        static double one_orukuru_bnb;
        static int count;

        static Int64 chanall_id = -1001200212136;
       static Int64 chat_id = -1001200993703;
       static Int64 chat_id_eng = -1001422174349;

        static string holder()
        {
            
                System.Net.WebClient wc = new System.Net.WebClient();
                string xc = wc.DownloadString(holder_url);

                var hold = JsonConvert.DeserializeObject<holders.Root>(xc);
                string holders = "Holders: " + hold.Data.Pagination.TotalCount;
                return holders;
            
            
}

        static string liq_method()
        {
           
                System.Net.WebClient wc = new System.Net.WebClient();
                string xc = wc.DownloadString(burn_furia_url);
                String one_stage = System.Text.RegularExpressions.Regex.Match(xc, @"<h6 class=""small text-uppercase text-secondary mb-1"">Balance</h6>\n+\S+").Groups[0].Value;
                var regex = new Regex(@"(\d{1,3},\d{3}(,\d{3})*)(\.\d*)?|\d+\.?\d");
                var burn_furia = Convert.ToString(regex.Match(one_stage));
                int dotIndex = burn_furia.IndexOf('.');
                if (dotIndex >= 0)
                {
                    burn_furia = burn_furia.Substring(0, dotIndex);
                }

                burn_furia = burn_furia.Replace(",", "");

                string burn_proocent = Math.Round((Convert.ToDouble(burn_furia) / 10000000000000), 5).ToString();
                //удаляем лишние числа после точки
                string out_burn = "Burned: " + burn_proocent + " %";
                return out_burn;
            
           
}

        //
        //
         static void Main(string[] args)
        {
            string orakuru_bot = "1";
            Bot_oru = new TelegramBotClient(orakuru_bot);
            Bot_oru.OnUpdate  += BotOnUpdate_oru;
            aTimer = new System.Timers.Timer(7774);
            aTimer.Elapsed += OnTimedEvent_oru;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Bot_oru.StartReceiving();

            string furia_dex_bot = "1";
               Bot = new TelegramBotClient(furia_dex_bot);
            Bot.OnUpdate += BotOnUpdate;
            aTimer = new System.Timers.Timer(5552);
               aTimer.Elapsed += OnTimedEvent;
               aTimer.AutoReset = true;
               aTimer.Enabled = true; 
               
                var me = Bot.GetMeAsync().Result;

                Console.WriteLine($"bot id:{me.Id }.bot name:{me.FirstName}");
                Bot.StartReceiving();
                Console.ReadLine();
          

        }
       
         public async static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                //test
                //Int64 chat_id = -1001423541408;
                //public -1001200212136
                string symbol = "FURIA";
                string contract = "0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f";
                //await Bot.SendTextMessageAsync(-1001200212136, "New news on the site.",ParseMode.Html, false, false, 0);

                //furia chanal  -1001200212136
                //amount0In - колво tpad sold "amount0In":[0-9]+.[0-9][0-9]
                //amount0Out - колво tpad buy "amount0Out":[0-9]+.[0-9][0-9]
                //amount1In - колво bnb buy "amount1In":[0-9]+.[0-9][0-9]
                //amount1Out - колво bnb sold "amount1Out":[0-9]+.[0-9][0-9]
                //amountUSD - колличество в usd "amountUSD":[0-9]+.[0-9][0-9]
                //blockNumber -id 



                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.101 Safari/537.36");
                wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;


                string json = wc.DownloadString("https://api.dex.guru/v2/tokens/" + contract + "-bsc/swaps?size=3");
                var s = JsonConvert.DeserializeObject<JSON.Root>(json);

                Thread.Sleep(500);
                //ликвидность
                string liquid_token_param = "https://api.beta.dex.guru/v1/tokens/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f?network=bsc";
                string liquid = wc.DownloadString(liquid_token_param);
                var liq = JsonConvert.DeserializeObject<betaguru.Root>(liquid);
                string liquid_out = (Math.Round(liq.LiquidityUSD, 2)).ToString() + " USDT";


                //колличество сожженных монет и процнет   
                //:https://bscscan.com/token/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f?a=0x000000000000000000000000000000000000dead


                ///
                //////
                //Convert.ToDecimal(number).ToString("#,##0.00"); преобразование

                string url_cake = "https://exchange.pancakeswap.finance/#/swap?outputCurrency=";
                string url_tranz = "https://bscscan.com/tx/";
                string id = s.Data[0].Id;
                string TransactionAddress = s.Data[0].TransactionAddress;
                var cs = trx_list.Any(item => item == id);
                var cc = tx_Hash.Any(item => item == TransactionAddress);
                string out_burn = liq_method();
                string out_holders = holder();
                //залоченная ликвидноостьь в USDT 


               

                for (int d = 0; d < s.Data.Count; d++)
                {
                    bool sss = TransactionAddress == tx_hash_proverka;
                    //buy           
                    if (s.Data[d].Amount0In == 0 && s.Data[d].Amount1Out == 0)
                    {

                        if (cc == false && json != json_proverka && json != null)
                        {
                            if (TransactionAddress != tx_hash_proverka)
                            {
                                
                                double usdt = (Math.Truncate(s.Data[d].AmountUSD * 10) / 10);
                                double furia = (Math.Truncate(s.Data[d].Amount0Out * 100) / 100);
                                string out_furia = Convert.ToDecimal(furia).ToString("#,##0");

                                double bnb = (Math.Truncate(s.Data[d].Amount1In * 10000) / 10000);
                                double one_tpad_u = ((s.Data[d].AmountUSD) / (s.Data[d].Amount0Out)) * 1000000000;

                                  one_furia_usdt = (Math.Round(one_tpad_u, 4)).ToString();


                                double one_furia_b = (s.Data[0].Amount0Out) / (s.Data[d].Amount1In);
                                double one_furia_bnb = Math.Truncate((one_furia_b * 100000) / 100000);
                                string out_furia_bnb = Convert.ToDecimal(one_furia_bnb).ToString("#,##0");

                                string buy_rok = "";
                                if (usdt > 100)
                                {
                                    buy_rok = "🌈🌈🌈" + "\n";
                                }
                                if (usdt > 1000)
                                {
                                    buy_rok = "🚀🚀🚀🚀🚀" + "\n";
                                }
                                if (usdt > 10000)
                                {
                                    buy_rok = "💹💹💹💹💹💹💹" + "\n";
                                }
                                tx_Hash.Add(s.Data[d].TransactionAddress);


                                Console.WriteLine("from data > " + s.Data[0].TransactionAddress);
                                Console.WriteLine("TRX->" + TransactionAddress + "\n" + tx_hash_proverka);
                                Console.WriteLine(sss);

                                tx_hash_proverka = TransactionAddress;

                                if(bnb>=1)
                                {
                                    await Bot.SendTextMessageAsync(chat_id,
            "🟢 Bought " + out_furia + " " + symbol + " for " + bnb + " BNB  on PancakeSwap" + "\n" + buy_rok + "\n" + "1B " + symbol + " = " + one_furia_usdt + " USDT" + "\n" + "1 BNB = " + out_furia_bnb + " " + symbol + "\n" + "\n" + out_holders + "\n" + out_burn + "\n" + "Liquidity: " + liquid_out + "\n" + "\n" + "[🥞 Buy " + symbol + "](" + url_cake + contract + ")" + " | " + "[📶 Tx Hash](" + url_tranz + TransactionAddress + ")" + " | " + "[🔒 LP Lockup](" + url_team_coins + ")" + "\n" + "[🔥 Burn TX](" + burn_furia_url + ")" + "      | " + "[📊 Chart](" + graph_url + ")" + "      | " + "[💵 Contract](" + usrl_contract + ")", ParseMode.Markdown, true);

                                }
                                await Bot.SendTextMessageAsync(chanall_id,
            "🟢 Bought " + out_furia + " " + symbol + " for " + bnb + " BNB  on PancakeSwap" + "\n" + buy_rok + "\n" + "1B " + symbol + " = " + one_furia_usdt + " USDT" + "\n" + "1 BNB = " + out_furia_bnb + " " + symbol + "\n" + "\n" + out_holders + "\n" + out_burn + "\n" + "Liquidity: " + liquid_out + "\n" + "\n" + "[🥞 Buy " + symbol + "](" + url_cake + contract + ")" + " | " + "[📶 Tx Hash](" + url_tranz + TransactionAddress + ")" + " | " + "[🔒 LP Lockup](" + url_team_coins + ")" + "\n" + "[🔥 Burn TX](" + burn_furia_url + ")" + "      | " + "[📊 Chart](" + graph_url + ")" + "      | " + "[💵 Contract](" + usrl_contract + ")", ParseMode.Markdown, true);




                                json_proverka = json;
                                Thread.Sleep(500);
                            }
                        }

                    }
                    //sold
                    if (s.Data[d].Amount1In == 0 && s.Data[d].Amount0Out == 0)
                    {

                        if (cc == false && json != json_proverka && json != null)
                        {
                            if ( TransactionAddress!= tx_hash_proverka )
                            { 
                                double usdt = (Math.Truncate(s.Data[d].AmountUSD * 10) / 10);
                                double furia = (Math.Truncate(s.Data[d].Amount0In * 100) / 100);

                                string out_furia = Convert.ToDecimal(furia).ToString("#,##0");
                                string bnb = (Math.Truncate(s.Data[d].Amount1Out * 10000) / 10000).ToString();
                                double one_furia_u = ((s.Data[d].AmountUSD) / (s.Data[d].Amount0In)) * 1000000000;
                                  one_furia_usdt = (Math.Round(one_furia_u, 4)).ToString();

                                double one_furia_b = (s.Data[d].Amount0In) / (s.Data[d].Amount1Out);
                                double one_furia_bnb = Math.Truncate((one_furia_b * 100000) / 100000);
                                string out_furia_bnb = Convert.ToDecimal(one_furia_bnb).ToString("#,##0");

                                string sell_rok = "";
                                if (usdt > 100)
                                {
                                    sell_rok = "⛔️⛔️⛔️" + "\n";
                                }
                                if (usdt > 1000)
                                {
                                    sell_rok = "💔💔💔💔💔" + "\n";
                                }
                                if (usdt > 10000)
                                {
                                    sell_rok = "🐹🐹🐹🐹🐹🐹🐹" + "\n";
                                }
                                tx_Hash.Add(s.Data[0].TransactionAddress);

                                Console.WriteLine("from data > " + s.Data[d].TransactionAddress);
                                Console.WriteLine("TRX->" + TransactionAddress + "\n" + tx_hash_proverka);
                                Console.WriteLine(sss);

                                tx_hash_proverka = TransactionAddress;
                                await Bot.SendTextMessageAsync(chanall_id,
            "🔴 Sold " + out_furia + " " + symbol + "  for " + bnb + " BNB on PancakeSwap" + "\n" + sell_rok + "\n" + "1B " + symbol + " = " + one_furia_usdt + " USDT" + "\n" + "1 BNB = " + out_furia_bnb + " " + symbol + "\n" + "\n" + out_holders + "\n" + out_burn + "\n" + "Liquidity: " + liquid_out + "\n" + "\n" + "[🥞 Buy " + symbol + "](" + url_cake + contract + ")" + " | " + "[📶 Tx Hash](" + url_tranz + TransactionAddress + ")" + " | " + "[🔒 LP Lockup](" + url_team_coins + ")" + "\n" + "[🔥 Burn TX](" + burn_furia_url + ")" + "      | " + "[📊 Chart](" + graph_url + ")" + "      | " + "[💵 Contract](" + usrl_contract + ")", ParseMode.Markdown, true);


                                json_proverka = json;
                                Thread.Sleep(500);
                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString()); ; return;
            } 
        }


        private static async void BotOnUpdate(object su, Telegram.Bot.Args.UpdateEventArgs evu)

        {
            try
            {
                var update = evu.Update;
                var message = update.Message;

                if (message == null) return;
                /*
                if (question1.Count == 2 || message.From.Username == @"off_fov")
                {
                    question1[1] = message.Text;
                    await Bot.SendTextMessageAsync(message.Chat.Id, question1[0] + "\n" + question1[1], ParseMode.Html, false, false, 0, keyboard_full);
                    await Bot.SendTextMessageAsync(message.Chat.Id, @"Вопрос ответ! Добавлен", ParseMode.Html, false, false, 0, keyboard_full);

                }*/

                if (message.Text == "/chart@FuriaRocketbot")
                {
                    double[] info_mass = new double[5];
                    info_mass = charts_dex.price();
                    await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                    string name_file = dex_dotnet_bot.charts_dex.chart();
                    Console.WriteLine(name_file);
                    string symbol = "FURIA";
                    string last_price = info_mass[0].ToString();
                    string Volume24h = info_mass[1].ToString("#,##0");
                    string Volume24hUSD = info_mass[2].ToString();
                    string LiquidityUSD = info_mass[3].ToString();
                    string Txns24h = info_mass[4].ToString();
                    await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price 1B FURIA: " + last_price + " USDT \n" + "Liquidity: " + LiquidityUSD + " FURIA \n" + "24H Volume: " + Volume24h + " USDT" + "\n" + "24H Volume USD: " + Volume24hUSD + " USDT" + "\n" + "View transactions:" + "</code>"+" @FuriaRocket" , ParseMode.Html, false, 0);
                    Thread.Sleep(500);
                }
                if (message.Text == "/price@FuriaRocketbot")
                {
                    double[] info_mass = new double[5];
                    info_mass = charts_dex.price();
                    await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                    string symbol = "FURIA";
                    string last_price = one_furia_usdt;
                    string Volume24h = info_mass[1].ToString("#,##0");
                    string Volume24hUSD = info_mass[2].ToString();
                    string LiquidityUSD = info_mass[3].ToString();
                    string Txns24h = info_mass[4].ToString();
                    await Bot.SendTextMessageAsync(message.Chat.Id, "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price 1B FURIA: " + last_price + " USDT \n" + "Liquidity: " + LiquidityUSD + " USDT \n" + "24H Volume: " + Volume24h + " FURIA" + "\n" + "24H Volume USD: " + Volume24hUSD + " USDT" +"\n" + "View transactions:" + "</code>" + " @FuriaRocket", ParseMode.Html, false);
                    Thread.Sleep(500);
                }

                var help_furia_keybooard = new InlineKeyboardMarkup(new[]
              {
                                         new [] { new InlineKeyboardButton { Text = "🔷 Как купить FURIA на Pancake swap", CallbackData = "demo", Url = "https://telegra.ph/Kak-priobresti-tokeny-FURIA-na-PancakeSwap-06-13" } },
                                         new [] { new InlineKeyboardButton { Text = "🔶 Купить FURIA на Pancake swap", CallbackData = "demo", Url = "https://exchange.pancakeswap.finance/#/swap?outputCurrency=0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f" } },
                              new [] { new InlineKeyboardButton { Text = "💹 Купить BNB", CallbackData = "demo", Url = "https://www.binance.cc/ru/futures/ref/Z6EIEROX" } },
                             new [] { new InlineKeyboardButton { Text = "🟣 Как купить FURIA через 1INCH?", CallbackData = "demo", Url = "https://telegra.ph/Kak-kupit-FURIA-cherez-prilozhenie-1INCH-06-24" } },
                            new [] { new InlineKeyboardButton { Text = "✔️ Пропал Dapp в TRUST?", CallbackData = "demo", Url = "https://telegra.ph/Kak-podklyuchitsya-k-PancakeSwap-cherez-Trust-Wallet-06-17" } } 
                                });

                var info_furia_keybooard = new InlineKeyboardMarkup(new[]
         {
                                         new [] { new InlineKeyboardButton { Text = "🚀 Сайт FURIA", CallbackData = "demo", Url = "https://furia.finance/" } },
                            new [] { new InlineKeyboardButton { Text = "🔖 Контракт FURIA", CallbackData = "demo", Url = "https://bscscan.com/address/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f" } },
                                         new [] { new InlineKeyboardButton { Text = "📊 График на Poocoin", CallbackData = "demo", Url = "https://poocoin.app/tokens/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f" } },
                            new [] { new InlineKeyboardButton { Text = "✔️ Аудит FURIA", CallbackData = "demo", Url = "https://www.certik.org/projects/furia" } },
                                 });

                var help_furia_keybooard_eng = new InlineKeyboardMarkup(new[]
       {
                                         new [] { new InlineKeyboardButton { Text = "🔷 How to buy FURIA tokens on PancakeSwap?", CallbackData = "demo", Url = "https://telegra.ph/How-to-buy-FURIA-tokens-on-PancakeSwap-06-13" } },

                                 });



                if (message.Text == "/help@FuriaRocketbot")
                {
                    if (message.Chat.Id == chat_id)
                    {
                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "FURIA help for you 💕", ParseMode.Html, false, false, 0, help_furia_keybooard);
                    }
                    if (message.Chat.Id == chat_id_eng)
                    {

                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "FURIA help for you 💕", ParseMode.Html, false, false, 0, help_furia_keybooard_eng);
                    }

                }
               

                if (message.Text == "/info@FuriaRocketbot")
                {

                    if (message.Chat.Id == chat_id)
                    {
                        await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        await Bot.SendTextMessageAsync(message.Chat.Id, "FURIA info for you 💕", ParseMode.Html, false, false, 0, info_furia_keybooard);
                    }
                    if (message.Chat.Id == chat_id_eng)
                    {

                    }
                        
                }

              
            }
            catch
            {

            }
        }


        private static   void BotOnUpdate_oru(object su, Telegram.Bot.Args.UpdateEventArgs evu)

        {
            try
            {
                var update = evu.Update;
                var message = update.Message;

                if (message == null) return;
                if (message.From.Id == 401036948 && message.Text != null)
                {
                    if (message.Text.Contains('<'))
                    {
                        string st = Regex.Replace(message.Text, "<", string.Empty);
                        one_orukuru_bnb = double.Parse(st, System.Globalization.CultureInfo.InvariantCulture);
                        count = 0;
                    }
                    if (message.Text.Contains('>'))
                    {
                        string st = Regex.Replace(message.Text, ">", string.Empty);
                        one_orukuru_bnb = double.Parse(st, System.Globalization.CultureInfo.InvariantCulture);
                        count = 1;
                    }


                }
                Console.WriteLine(one_orukuru_bnb);

            }
            catch
            {

            }
        }


        public async static void OnTimedEvent_oru(object source, ElapsedEventArgs e)
        {
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.101 Safari/537.36");
                wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                Thread.Sleep(500);  
                string contract = "0xced0ce92f4bdc3c2201e255faf12f05cf8206da8";

                string json = wc.DownloadString("https://api.dex.guru/v2/tokens/" + contract + "-bsc/swaps?size=3");
                var s = JsonConvert.DeserializeObject<JSON.Root>(json);
                Thread.Sleep(500);

                string id = s.Data[0].Id;
                string TransactionAddress = s.Data[0].TransactionAddress;
                var cs = trx_list.Any(item => item == id);
                var cc = tx_Hash.Any(item => item == TransactionAddress);

                for (int d = 0; d < s.Data.Count; d++)
                {
                    //buy           
                    if (s.Data[d].Amount0In == 0 && s.Data[d].Amount1Out == 0)
                    {

                        if (cc == false && json != null)
                        {
                            double one_oru_u = Math.Round((s.Data[d].AmountUSD) / (s.Data[d].Amount1In),5);
                            double one_oru_bnb_if = (Math.Round((s.Data[d].Amount1In) / (s.Data[d].Amount0Out), 5));

                            tx_Hash.Add(s.Data[d].TransactionAddress);

                            Console.WriteLine("from data > " + s.Data[0].TransactionAddress);

                            if (count == 0)
                            {

                                if (one_oru_bnb_if < one_orukuru_bnb)
                                {
                                    await Bot_oru.SendTextMessageAsync(-1001331407433, one_oru_bnb_if.ToString()+"\n" + one_oru_u.ToString(), ParseMode.Markdown, true);
                                }

                                Thread.Sleep(500);
                            }
                            if (count == 1)
                            {

                                if (one_oru_bnb_if > one_orukuru_bnb)
                                {
                                    await Bot_oru.SendTextMessageAsync(-1001331407433, one_oru_bnb_if.ToString() + "\n" + one_oru_u.ToString(), ParseMode.Markdown, true);
                                }

                                Thread.Sleep(500);
                            }


                            Thread.Sleep(500);
                        }

                    }
                    //sold
                    if (s.Data[d].Amount1In == 0 && s.Data[d].Amount0Out == 0)
                    {

                        if (cc == false && json != null)
                        {
                            double one_oru_u = ((s.Data[d].AmountUSD) / (s.Data[d].Amount1Out));
                            double one_oru_bnb_if = (Math.Round((s.Data[d].Amount1Out) / (s.Data[d].Amount0In), 5));


                            tx_Hash.Add(s.Data[0].TransactionAddress);

                            Console.WriteLine("from data > " + s.Data[d].TransactionAddress);

                            if (count == 0)
                            {

                                if (one_oru_bnb_if < one_orukuru_bnb)
                                {
                                    await Bot_oru.SendTextMessageAsync(-1001331407433, one_oru_bnb_if.ToString() + "\n" + one_oru_u.ToString(), ParseMode.Markdown, true);
                                }

                                Thread.Sleep(500);
                            }
                            if (count == 1)
                            {

                                if (one_oru_bnb_if > one_orukuru_bnb)
                                {
                                    await Bot_oru.SendTextMessageAsync(-1001331407433, one_oru_bnb_if.ToString() + "\n" + one_oru_u.ToString(), ParseMode.Markdown, true);
                                }

                                Thread.Sleep(500);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); ; return;
            }
        }

    }


        // запускаем прием обновлений



    }


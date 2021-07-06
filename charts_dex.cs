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

namespace dex_dotnet_bot
{
    class charts_dex
    {

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            return origin.AddSeconds(timestamp);

        }
        public static double[] price()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            double[] info_mass = new double[5];
            System.Net.WebClient wc = new System.Net.WebClient();
            System.Net.WebClient wc2 = new System.Net.WebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");
            wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            string json = wc.DownloadString("https://api.beta.dex.guru/v1/tokens/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f?network=bsc");
            var data = JsonConvert.DeserializeObject<info_json.Root>(json); 
             
            /*

            string bscsan_sid = wc.DownloadString("https://bscscan.com/token/0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f");
            String one_stage = System.Text.RegularExpressions.Regex.Match(bscsan_sid, @"var.sid.=..\w+").Groups[0].Value; 
            var regex = new Regex(@"'[^ ]+");
            var cid_pre = Convert.ToString(regex.Match(one_stage));
            string sid = cid_pre.Trim(new char[]{(char)39});
            string url = "https://bscscan.com/token/generic-tokentxns2?m=normal&contractAddress=0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f&a=&sid=" + sid + "&p=1";
            string bscsan_trx_sum = wc.DownloadString(url);
           
            Console.WriteLine(url);
             */
            info_mass[0] = Math.Round(data.PriceUSD * 1000000000, 4);
            info_mass[1] = data.Volume24h;
            info_mass[2] = Math.Round(data.Volume24hUSD, 2);
            info_mass[3] = Math.Round(data.LiquidityUSD, 2);
            info_mass[4] = data.Txns24h;
            return info_mass;
        }

        public static string chart()
        {

            System.Net.WebClient wc = new System.Net.WebClient();
            System.Net.WebClient wc2 = new System.Net.WebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");
            wc.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wc2.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");
            wc2.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            string to_time = wc.DownloadString("https://api.beta.dex.guru/v1/tradingview/time");
            string from_time = (Convert.ToInt32(to_time) - 172800).ToString();
            String link_Response = wc2.DownloadString("https://api.dex.guru/v1/tradingview/history?symbol=0x8500c4a12ce0ea7b16c3e8c959ecf7837fbaf93f-bsc_USD&resolution=30&from=" + from_time + "&to=" + to_time + "&currencyCode=USD");
            var data = JsonConvert.DeserializeObject<JSON_chart.Root>(link_Response);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");



            //Оишбка в апи hbc в конце несколкьо нулей 0 0 0 0 0
            //введен костыль-переменная 
            int count = data.O.Count ;
            ScottPlot.OHLC[] ohlcs = new ScottPlot.OHLC[count];
            var plt = new ScottPlot.Plot(800, 400);
            double last_price = Math.Round(data.C[count-1] * 1000000000, 4);
            for (int i = 0; i < count; i++)
            {
                double Open = Math.Round(data.O[i] * 1000000000, 4);
                double High = Math.Round(data.H[i] * 1000000000, 4);
                double Low = Math.Round(data.L[i] * 1000000000, 4);
                double Close = Math.Round(data.C[i] * 1000000000, 4);
                double Opentime = ((Convert.ToDouble(data.T[i])) / 1000) + (3600 * 3);
                ohlcs[i] = new ScottPlot.OHLC(Open, High, Low, Close, ConvertFromUnixTimestamp(data.T[i]), 1);


            }

            plt.Title("30 Minute Chart (Price for 1B FURIA)");
            plt.YLabel("Stock Price (FURIAUSDT)");
            plt.Ticks(dateTimeX: true, dateTimeFormatStringX: "HH:mm:ss", numericFormatStringY: "n");
            plt.PlotCandlestick(ohlcs);
            plt.Style(tick: Color.White, label: Color.White, title: Color.White, dataBg: Color.FromArgb(255, 36, 43, 60), grid: Color.FromArgb(255, 36, 43, 60), figBg: Color.FromArgb(255, 36, 43, 60));
            DateTime date1 = new DateTime();
            date1 = DateTime.Now;

            string name = "PlotTypes №" + date1.Ticks + ".png";

            string name_file = name;
            string label_name = Convert.ToString(last_price + " USDT");
            plt.PlotHLine(y: last_price, color: Color.Green, lineWidth: 0.5, label: label_name);
            plt.Legend(backColor: Color.FromArgb(255, 36, 43, 60), location: legendLocation.upperCenter);



            plt.SaveFig(name_file);



            return name_file;
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KanyeandRonSwanson
{
    public class QuoteGenerator
    {
        public static string GetKanyeQuote()
        {
            var client = new HttpClient(); //make a request to the internet

            var kanyeURL = "https://api.kanye.rest/";

            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;
        }
        public static string GetRonSwansonQuote()
        {
            var client = new HttpClient();
            var ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = client.GetStringAsync(ronSwansonURL).Result;

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            return ronQuote;
        }
        public static void GenerateConversation()
        {
            for (int i = 0; i < 5; i++)
            {
                var kanyeSays = QuoteGenerator.GetKanyeQuote();
                Console.WriteLine($"Kanye: \"{kanyeSays}\"");
                var ronSays = QuoteGenerator.GetRonSwansonQuote();
                Console.WriteLine($"Ron Swanson: {ronSays}\n");
            }
        }
    }
}

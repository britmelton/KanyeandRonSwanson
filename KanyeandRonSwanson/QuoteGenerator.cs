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

        private HttpClient _client;

        public QuoteGenerator(HttpClient client) //make a request to the internet
        {
            _client = client;
        }
        public string GetKanyeQuote()
        {
            var kanyeURL = "https://api.kanye.rest/";

            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;
        }
        public string GetRonSwansonQuote()
        {
          
            var ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = _client.GetStringAsync(ronSwansonURL).Result;

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            return ronQuote;
        }
        public static void GenerateConversation()
        {

            var client = new HttpClient();
            var quote = new QuoteGenerator(client);
            for (int i = 0; i < 5; i++)
            {
                var kanyeSays = quote.GetKanyeQuote();
                Console.WriteLine($"Kanye: \"{kanyeSays}\"");
                var ronSays = quote.GetRonSwansonQuote();
                Console.WriteLine($"Ron Swanson: {ronSays}\n");
            }
        }
    }
}

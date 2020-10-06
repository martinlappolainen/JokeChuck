using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace ChuckApi
{
    class Program
    {
        private static string url = "https://api.chucknorris.io/jokes/random";
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var WebResponse = request.GetResponse();
            var webStream = WebResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();

                Joke joke = JsonConvert.DeserializeObject<Joke>(response);
                Console.WriteLine($"Joke:{joke.Value}");
            }
        }
    }
}

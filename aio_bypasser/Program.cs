using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BypassVIP_API
{
    internal class Response
    {
        public bool Success { get; set; }
        public string Website { get; set; }
        public string Query { get; set; }
        public string Destination { get; set; }
        public bool Cache { get; set; }
        public int TimeMs { get; set; }

    }

    public static class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(@"
                 █████╗ ██╗ ██████╗     ██████╗ ██╗   ██╗██████╗  █████╗ ███████╗███████╗███████╗██████╗ 
                ██╔══██╗██║██╔═══██╗    ██╔══██╗╚██╗ ██╔╝██╔══██╗██╔══██╗██╔════╝██╔════╝██╔════╝██╔══██╗
                ███████║██║██║   ██║    ██████╔╝ ╚████╔╝ ██████╔╝███████║███████╗███████╗█████╗  ██████╔╝
                ██╔══██║██║██║   ██║    ██╔══██╗  ╚██╔╝  ██╔═══╝ ██╔══██║╚════██║╚════██║██╔══╝  ██╔══██╗
                ██║  ██║██║╚██████╔╝    ██████╔╝   ██║   ██║     ██║  ██║███████║███████║███████╗██║  ██║
                ╚═╝  ╚═╝╚═╝ ╚═════╝     ╚═════╝    ╚═╝   ╚═╝     ╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝
                                        https://github.com/TWIST-X7/Aio-Bypasser
                                                Made By TWISTX7#9122
");
                Console.ResetColor();
                Console.Write("Enter your url here: ");
                string userinput = Console.ReadLine();
                var result = Bypass(userinput).Result;
                if (result.Success == true)
                {
                    Console.WriteLine("");
                    var originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Bypassing : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(result.Success + "\n");
                    Console.ForegroundColor = originalColor;
                    var originalColor2 = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Website : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(result.Website + "\n");
                    Console.ForegroundColor = originalColor2;
                    var originalColor3 = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Original Url : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(result.Query + "\n");
                    Console.ForegroundColor = originalColor3;
                    var originalColor4 = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Bypassed Url : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(result.Destination + "\n");
                    Console.ForegroundColor = originalColor4;

                    //Console.WriteLine(result.TimeMs);
                    Console.WriteLine("");
                    Console.Write("Press Anything To Continue...");
                    string user = Console.ReadLine();
                }
                else if (result.Success == false)
                {
                    Console.WriteLine("");
                    var originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Error : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Unsupported Url ! Or Try Again!" + "\n");
                    Console.ForegroundColor = originalColor;
                    Console.WriteLine("");
                    Console.Write("Press Anything To Try Again...");
                    string user = Console.ReadLine();
                }


            }
        }

        private static async Task<Response> Bypass(string url)
        {
            var values = new Dictionary<string, string>
            {
                {"url", url}
            };

            var response = await Client.PostAsync("https://api.bypass.vip/", new FormUrlEncodedContent(values));
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response>(responseString);
        }
    }
}

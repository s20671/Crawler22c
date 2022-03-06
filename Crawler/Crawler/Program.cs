using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            var websiteUrl = args[0];
            Console.WriteLine(websiteUrl);

            var https = new HttpClient();

            var response = await https.GetAsync(websiteUrl);
            Console.WriteLine(response);

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content); 
            
            var a = $"Content {content}";
            var b = @"\.-]";
            var regex = new Regex("([a-zA-Z0-9+._-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z0-9_-]+)");


            var matchCollection = regex.Matches(content);

           

            foreach(var item in matchCollection)
            {
                Console.WriteLine(item);
            }


        }
    }
}

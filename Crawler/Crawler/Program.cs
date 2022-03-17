using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler {
    public class Program {
        public static async Task Main(string[] args) {
            if (args.Length <1) { throw new ArgumentNullException("No URL Address"); } 
            string websiteUrl = args[0];
            if (!(Uri.IsWellFormedUriString(websiteUrl, UriKind.Absolute))) throw new ArgumentException("Incorrect URL");
            var httpClient = new HttpClient();
            try {
                var response = await httpClient.GetAsync(websiteUrl);

                if (response.IsSuccessStatusCode) {
                    var siteContent = await response.Content.ReadAsStringAsync();
                    var pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    Regex regex = new(pattern, RegexOptions.IgnoreCase); 
                    var mathCollection = regex.Matches(siteContent);
                    var set = new HashSet<string>();
                    foreach (var item in mathCollection)
                    {
                        set.Add(item.ToString());
                    }
                        
                    if (set.Count >= 1)
                    {
                        foreach (var item in set)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else { 
                        Console.WriteLine("No Mail addresses"); 
                    }    
                }
            }
            catch (Exception e) {
                Console.WriteLine("Error during site downland: " + e.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBrowser
{
    internal class Client
    {
        HttpClient client = new HttpClient();

        public async Task<string> getWebsite(string site)
        {
            try
            {
                //Get the html from website
                HttpResponseMessage response = await client.GetAsync(site);
                response.EnsureSuccessStatusCode();
                //Put it all into a string
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (Exception)
            {
                Console.WriteLine("SOMETHING WENT WRONG");
            }
            return "";
        }
    }
}

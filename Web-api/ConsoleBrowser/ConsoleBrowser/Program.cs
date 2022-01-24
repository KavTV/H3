using System;
using System.Net.Http;
using System.Text;

namespace ConsoleBrowser
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            Client client = new Client();
            HtmlFormatter formatter = new HtmlFormatter();

            //Im using formathtml but i also made formathtmlcompact, that sometimes look prettier
            string formattedHtml = formatter.FormatHtml(client.getWebsite("https://www.lipsum.com/").Result);

            Console.WriteLine(formattedHtml);

            Console.ReadLine();
        }

        
    }
}

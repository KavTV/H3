using System;
using System.Net.Http;
using System.Text;

namespace ConsoleBrowser
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

                Client client = new Client();
                HtmlFormatter formatter = new HtmlFormatter();

                Console.WriteLine("INPUT WEBSITE");
                string input = Console.ReadLine();
                //Im using formathtml but i also made formathtmlcompact, that sometimes look prettier
                string formattedHtml = formatter.FormatHtml(client.getWebsite(input).Result);

                Console.WriteLine(formattedHtml);

                Console.ReadLine();
            }
        }


    }
}

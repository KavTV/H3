using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleBrowser
{
    internal class HtmlFormatter
    {
        public string FormatHtml(string html)
        {
            string[] matches = splitHtml(html);
            string formattedHtml = "";

            //Just add the html without tags into a string
            for (int i = 0; i < matches.Length; i++)
            {
                string match = matches[i];
                formattedHtml += match;
            }

            return formattedHtml;
        }


        public string FormatHtmlCompact(string html)
        {
            //This triggers if a string only contains \n and no text
            Regex filterRegex = new Regex(@"\n[^\w]", RegexOptions.Compiled);

            string[] matches = splitHtml(html);

            string formattedHtml = "";

            //Some items in the array is empty or only contains \n
            for (int i = 0; i < matches.Length; i++)
            {
                string match = matches[i];
                //If the string only contains an \n and whitespace,dont add it
                if (!filterRegex.IsMatch(match) && !string.IsNullOrWhiteSpace(match))
                {
                    formattedHtml += match + "\n";
                }
            }


            return formattedHtml;
        }

        private static string[] splitHtml(string html)
        {
            //This regex will seperate the html tags
            Regex htmlRegex = new Regex("<[^<]*>", RegexOptions.Compiled);

            //We need to get the text inside the tags
            //Doing it this way makes us unable to see what tags the text is enclosed in
            string[] matches = htmlRegex.Split(html);
            return matches;
        }
    }
}
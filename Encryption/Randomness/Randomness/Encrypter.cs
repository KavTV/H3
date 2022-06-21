using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomness
{
    public class Encrypter
    {

        static char[] code = 
            "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ".ToCharArray();

        public static string Encrypt(string message)
        {
            char[] messageChar = message.ToCharArray();
            string newString = "";
            for (int i = 0; i < messageChar.Length; i++)
            {
                //Make it in uppercase when searching
                char ch = Char.ToUpper(messageChar[i]);
                //Find index in array where character is present
                int index = Array.IndexOf(code, ch);

                //Edge detection
                if (index == 0)
                {
                    index = code.Length;
                }
                else if (index == code.Length)
                {
                    index = 0;
                }

                //Add 1 for the next number in alphabet
                newString += code[index + 1];

            }
            return newString;
        }

        public static string Decrypt(string message)
        {
            char[] messageChar = message.ToCharArray();
            string newString = "";
            for (int i = 0; i < messageChar.Length; i++)
            {
                //Make it in uppercase when searching
                char ch = Char.ToUpper(messageChar[i]);
                //Find index in array where character is present
                int index = Array.IndexOf(code, ch);

                //Edge detection
                if (index == 0)
                {
                    index = code.Length;
                }
                else if(index == code.Length)
                {
                    index = 0;
                }

                //Remove 1 for the normal alphabet
                newString += code[index - 1];

            }
            return newString;
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace AsymmetricEncryptionReceiver
{
    internal class Program
    {
        static void Main(string[] args)
        {


            using (RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider(4096))
            {

                //I use false, because i dont need the private params to show
                var rsaParams = myRSA.ExportParameters(false);

                //Print params
                PrintParameters(rsaParams);

                while (true)
                {
                    //Got to remove the - for the fromhexstring to work
                    Console.WriteLine("Write message to decrypt");
                    string msgToDecrypt = Console.ReadLine().Replace("-", "");

                    //Convert msg to bytes
                    byte[] msgBytes = Convert.FromHexString(msgToDecrypt);

                    //Decrypt the message
                    byte[] decryptedMsg = myRSA.Decrypt(msgBytes, true);

                    Console.WriteLine(Encoding.UTF8.GetString(decryptedMsg));
                }
            }


            Console.ReadLine();
        }

        private static void PrintParameters(RSAParameters rsaParams)
        {
            string exponent = BitConverter.ToString(rsaParams.Exponent);
            string modulus = BitConverter.ToString(rsaParams.Modulus);


            Console.WriteLine($"\nExponent: {exponent}" +
                $"\nModulus: {modulus}");
        }
    }
}

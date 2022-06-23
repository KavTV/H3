using System;
using System.Security.Cryptography;
using System.Text;

namespace AsymmetricEncryptionSender
{
    internal class Program
    {
        /// <summary>
        /// This program can encrypt
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            RSAParameters rsaParams = AskRSAParams();
            //Make sure rsa gets disposed automatically
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(4096))
            {
                //Import the parameters
                rsa.ImportParameters(rsaParams);

                while (true)
                {
                    Console.WriteLine("Write message to encrypt");

                    string msg = Console.ReadLine();

                    byte[] msgBytes = Encoding.ASCII.GetBytes(msg);

                    //Encrypt the message with the public key we got.
                    byte[] encryptedMsgByte = rsa.Encrypt(msgBytes, true);

                    string encryptedMsg = BitConverter.ToString(encryptedMsgByte);
                    Console.WriteLine($"\nEncryptedMsg: {encryptedMsg}");

                }
            }


        }

        private static RSAParameters AskRSAParams()
        {
            Console.WriteLine("Insert Exponent:");
            //Replace the - with nothing, since it is not needed when converting to hex string
            string exponent = Console.ReadLine().Replace("-", "");

            Console.WriteLine("Insert Modulus");
            string modulus = Console.ReadLine().Replace("-", "");

            //Set the exponent and modulus from the generated public key, from the other program
            RSAParameters rsaParams = new RSAParameters
            {
                Exponent = Convert.FromHexString(exponent),
                Modulus = Convert.FromHexString(modulus)
            };
            return rsaParams;
        }
    }
}

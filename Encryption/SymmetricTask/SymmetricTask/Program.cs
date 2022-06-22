using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SymmetricTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Get user symmetric method
                SymmetricAlgorithm sa = EncryptionMethodMenu();
                Stopwatch sw = new Stopwatch();

                if (SelectTypeMenu() == "1")
                {
                    string msg = AskForMessage();

                    //Start timer and begin encryption
                    sw.Start();
                    byte[] encryptedMsg = Encrypter.Encrypt(sa, msg);
                    sw.Stop();

                    //Print result
                    PrintResult(Convert.ToBase64String(encryptedMsg), sa.Key, sa.IV, sw.Elapsed);

                }
                else
                {
                    string msg = AskForMessage();

                    Console.WriteLine("Write the key");
                    string key = Console.ReadLine();

                    Console.WriteLine("Write the IV");
                    string iV = Console.ReadLine();

                    //Set user defined key and IV
                    sa.Key = Convert.FromBase64String(key);
                    sa.IV = Convert.FromBase64String(iV);

                    //Start timer and begin decryption
                    sw.Start();
                    string decryptedMsg = Encrypter.Decrypt(sa, msg);
                    sw.Stop();
                    
                    PrintResult(decryptedMsg, sa.Key, sa.IV,sw.Elapsed);
                }

            }

        }

        private static void PrintResult(string encryptedMsg, byte[] key, byte[] iv, TimeSpan time)
        {
            string hexMsg = Convert.ToHexString(Encoding.ASCII.GetBytes(encryptedMsg));
            string keyMsg = Convert.ToBase64String(key);
            string iV = Convert.ToBase64String(iv);

            Console.WriteLine(
                $"\nASCII: {encryptedMsg}" +
                $"\nHEX: {hexMsg}" +
                $"\nKEY: {keyMsg}" +
                $"\nIV: {iV}" +
                $"\nTIME: {time}");
        }

        static string AskForMessage()
        {
            Console.WriteLine("Write a message");
            return Console.ReadLine();
        }

        static string SelectTypeMenu()
        {
            Console.WriteLine("" +
                "\n1: Encrypt" +
                "\n2: Decrypt");

            return Console.ReadLine();
        }

        static SymmetricAlgorithm EncryptionMethodMenu()
        {
            Console.WriteLine("" +
                "\nSelect Method" +
                "\n1: DES" +
                "\n2: 3DES" +
                "\n3: AES" +
                "\n4: RC2" +
                "\n5: Rijndael");

            switch (Console.ReadLine())
            {
                case "1":
                    return DES.Create();
                case "2":
                    return TripleDES.Create();
                case "3":
                    return Aes.Create();
                case "4":
                    return RC2.Create();
                case "5":
                    return Rijndael.Create();
                default:
                    return Aes.Create();
            }
        }


        
    }
}

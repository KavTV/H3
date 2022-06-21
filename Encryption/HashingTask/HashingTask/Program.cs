using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace HashingTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                if (StartMenu() == "1")
                {
                    //THIS IS FOR HASHING
                    HashAlgorithm hashAlgo = HashMenu();

                    Console.WriteLine("Write message");
                    string inputMsg = Console.ReadLine();

                    //Get the bytes from the message
                    byte[] message = Encoding.ASCII.GetBytes(inputMsg);

                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    byte[] hash = hashAlgo.ComputeHash(message);
                    sw.Stop();

                    string convertBase = Convert.ToBase64String(hash);
                    string convertString = Convert.ToHexString(hash);

                    Console.WriteLine($"ASCII: {convertBase}");
                    Console.WriteLine($"HEX: {convertString}");
                    Console.WriteLine($"TIME: {sw.Elapsed}");
                }
                else
                {
                    //THIS IS FOR HMAC
                    HMAC hmac = HmacMenu();

                    Console.WriteLine("Write message");
                    string inputMsg = Console.ReadLine();

                    //Get the bytes from the message
                    byte[] message = Encoding.ASCII.GetBytes(inputMsg);
                    //Compute hash
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    byte[] computed = ComputeMAC(hmac, message);
                    sw.Stop();

                    string convertBase = Convert.ToBase64String(computed);
                    string convertString = Convert.ToHexString(computed);


                    Console.WriteLine($"KEY: {Convert.ToBase64String(hmac.Key)}");
                    Console.WriteLine($"ASCII: {convertBase}");
                    Console.WriteLine($"HEX: {convertString}");
                    Console.WriteLine($"TIME: {sw.Elapsed}");

                    bool whileBool = true;
                    while (whileBool)
                    {
                        Console.WriteLine("Check authenticity, write 'NO' to exit");

                        string authenInput = Console.ReadLine();

                        if (authenInput != "NO")
                        {
                            Console.WriteLine(CheckAuthenticity(hmac, Encoding.ASCII.GetBytes(authenInput), computed));

                        }
                        else
                        {
                            whileBool = false;
                        }
                    }

                }
            }
        }


        static string StartMenu()
        {
            Console.WriteLine(
                "\n1: Hash \n" +
                "2: HMAC");

            return Console.ReadLine();
        }

        static HashAlgorithm HashMenu()
        {
            Console.WriteLine("" +
                "\n1: SHA1 \n" +
                "2: MD5 \n" +
                "3: SHA256\n" +
                "4: SHA384\n" +
                "5: SHA512\n");

            switch (Console.ReadLine())
            {
                case "1":
                    return SHA1.Create();
                case "2":
                    return MD5.Create();
                case "3":
                    return SHA256.Create();
                case "4":
                    return SHA384.Create();
                case "5":
                    return SHA512.Create();
                default:
                    return SHA1.Create();
            }


        }

        static HMAC HmacMenu()
        {
            Console.WriteLine("" +
                "1: SHA1 \n" +
                "2: MD5 \n" +
                "3: SHA256\n" +
                "4: SHA384\n" +
                "5: SHA512\n");

            byte[] key = GenerateKey();

            switch (Console.ReadLine())
            {
                case "1":
                    return new HMACSHA1(key);
                case "2":
                    return new HMACMD5(key);
                case "3":
                    return new HMACSHA256(key);
                case "4":
                    return new HMACSHA384(key);
                case "5":
                    return new HMACSHA512(key);

                default:
                    return new HMACSHA1(key);
            }
        }

        static byte[] ComputeMAC(HMAC hmac, byte[] message)
        {
            return hmac.ComputeHash(message);
        }

        static bool CheckAuthenticity(HMAC hmac, byte[] message, byte[] mac)
        {

            if (CompareByteArrays(hmac.ComputeHash(message), mac, hmac.HashSize / 8) == true)
            {
                return true;
            }

            return false;
        }

        static bool CompareByteArrays(byte[] a, byte[] b, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        static byte[] GenerateKey()
        {
            RandomNumberGenerator rnd = RandomNumberGenerator.Create();
            byte[] key = new byte[16];
            rnd.GetBytes(key);

            return key;
        }
    }
}

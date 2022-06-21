using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace Randomness
{
    internal class Program
    {
        const int numberAmount = 100000;
        static void Main(string[] args)
        {
            Stopwatch swCryp = new Stopwatch();
            Stopwatch swRnd = new Stopwatch();
            swCryp.Start();

            CryptoRandom(numberAmount);
            swCryp.Stop();

            swRnd.Start();

            RandomNumber(numberAmount);
            swRnd.Stop();

            Console.WriteLine($"Crypto random number took: {swCryp.Elapsed}");
            Console.WriteLine($"Pseudo number took: {swRnd.Elapsed}");

            Console.WriteLine($"Encryption of Hello: {Encrypter.Encrypt("Hello")}");
            Console.WriteLine($"Decryption of IFMMP: {Encrypter.Decrypt("IFMMP")}");
            Console.ReadLine();
        }

        private static void CryptoRandom(int numbers)
        {
            List<int> ints = new List<int>();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];

                for (int i = 0; i < numbers; i++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    rng.GetBytes(data);

                    int value = BitConverter.ToInt32(data, 0);
                    sw.Stop();

                    ints.Add(value);
                    //Console.WriteLine($"CRYPTO: {value} took: {sw.Elapsed}");
                }
            }

            var grouped = ints.GroupBy(x => x).Select(x => new { Number = x.Key, Times = x.Count() }).ToList();

            var groupedDoubleNumbers = grouped.Where(x => x.Times > 1);

            Console.WriteLine("CRYPTO: Amount of times the same number appers");
            foreach (var item in groupedDoubleNumbers)
            {
                Console.WriteLine($"CRYPTO: The amount of times a a number is the same: {item.Number} times: {item.Times}");
            }
        }

        private static void RandomNumber(int numbers)
        {
            List<int> ints = new List<int>();

            Random random = new Random();

            for (int i = 0; i < numbers; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                int rnd = random.Next();

                sw.Stop();

                ints.Add(rnd);
                //Console.WriteLine($"PSEUDO: {rnd} Took: {sw.Elapsed}");
            }

            var grouped = ints.GroupBy(x => x).Select(x => new { Number = x.Key, Times = x.Count() }).ToList();

            var groupedDoubleNumbers = grouped.Where(x => x.Times > 1);

            Console.WriteLine("PSEUDO: Amount of times the same number appers");
            foreach (var item in groupedDoubleNumbers)
            {
                Console.WriteLine($"PSEUDO: The amount of times a a number is the same: {item.Number} times: {item.Times}");
            }
        }
    }
}

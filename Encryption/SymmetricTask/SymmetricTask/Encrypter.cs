using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricTask
{
    public class Encrypter
    {
        public static byte[] Encrypt(SymmetricAlgorithm sa, string message)
        {
            //Convert message to byte array
            byte[] messageByte = Encoding.ASCII.GetBytes(message);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(messageByte, 0, messageByte.Length);
            cs.Close();

            return ms.ToArray();
        }

        public static string Decrypt(SymmetricAlgorithm sa, string message)
        {
            byte[] decrypted = new byte[message.Length];
            //Convert message to byte array
            byte[] messageByte = Convert.FromBase64String(message);

            using (MemoryStream ms = new MemoryStream(messageByte))
            {
                using (CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader((Stream)cs))
                    {
                        return sr.ReadToEnd();
                    }

                }
            }

        }
    }
}

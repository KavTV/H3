using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswordTask
{
    public class PBKDF2
    {
        public static string GenerateSalt()
        {
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32];

                randomGenerator.GetBytes(salt);

                return Convert.ToBase64String(salt);
            }

        }

        public static string ComputeHash(string password, string salt, int iterations)
        {
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);

            //Setting the iterations and hashing algorithm in the constructor
            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(passwordBytes, saltBytes, iterations, HashAlgorithmName.SHA512))
            {
                return Convert.ToBase64String(hashGenerator.GetBytes(32));
            }
        }

        public static bool VerifyHash(string password, User user)
        {
            //hash the password user just entered, with found user salt
            string newHash = ComputeHash(password, user.Salt, user.Iterations);

            //If hashes match, it is the same password
            if (newHash == user.Hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

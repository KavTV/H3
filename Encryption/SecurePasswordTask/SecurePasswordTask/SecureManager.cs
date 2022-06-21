using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswordTask
{
    public class SecureManager
    {
        public static bool VerifyUser(string username, string password)
        {
            //Get user from database
            User foundUser = DAL.GetUser(username);

            //If no user was found, we cant verify it
            if (foundUser == null)
            {
                return false;
            }

            //hash the password user just entered, with found user salt
            string newHash = PBKDF2.ComputeHash(password, foundUser.Salt, foundUser.Iterations);

            //If hashes match, it is the same password
            if (newHash == foundUser.Hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void LockUser(string username)
        {
            DAL.LockUser(username);
        }

        public static void CreateUser(string username, string password)
        {
            const int iteration = 10000;
            string salt = PBKDF2.GenerateSalt();
            string hash = PBKDF2.ComputeHash(password, salt, iteration);

            DAL.CreateUser(new User(username,hash,salt, iteration));
        }
    }
}

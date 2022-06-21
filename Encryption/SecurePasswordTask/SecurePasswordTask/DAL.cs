using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswordTask
{
    public class DAL
    {
        public static List<User> Users = new List<User>();


        public static void CreateUser(User user)
        {
            Users.Add(user);
        }
        public static User GetUser(string username)
        {
            return Users.Find(x => x.Username == username && x.Locked == false);
        }
        public static void LockUser(string username)
        {
            try
            {
                Users.Find(x => x.Username == username).Locked = true;

            }
            catch (Exception)
            {
                Console.WriteLine("User does not exist");
            }
        }
    }
}

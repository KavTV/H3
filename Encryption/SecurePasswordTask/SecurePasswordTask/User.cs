using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswordTask
{
    public class User
    {
        public string Username { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

        //In case iterations get changed in the future we need to save it for specific user
        public int Iterations { get; set; }
        public bool Locked = false;

        public User(string username, string hash, string salt, int iterations)
        {
            Username = username;
            Hash = hash;
            Salt = salt;
            Iterations = iterations;
        }
    }
}

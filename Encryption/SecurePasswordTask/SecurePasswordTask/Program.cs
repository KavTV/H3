using System;

namespace SecurePasswordTask
{
    internal class Program
    {
        static int tries = 0;
        static int maxTries = 5;

        static void Main(string[] args)
        {
            while (true)
            {

                if (StartMenu() == "1")
                {
                    CreateUser();
                }
                else
                {
                    tries = 0;
                    bool loggedIn = false;

                    Console.WriteLine("Enter username");
                    string username = Console.ReadLine();

                    //Only try to log in if user exists
                    if (SecureManager.UserExist(username))
                    {
                        while (tries < maxTries && loggedIn == false)
                        {
                            loggedIn = LogIn(username);

                            if (loggedIn == true)
                            {
                                break;
                            }
                            tries++;

                            Console.WriteLine($"You have {maxTries - tries} tries left");
                        }
                        if (loggedIn == false)
                        {
                            //Eventually add a timer before user can log in again
                            SecureManager.LockUser(username);
                            Console.WriteLine($"{username} blocked");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User does not exist or is blocked");
                    }
                }
            }
        }

        private static bool LogIn(string username)
        {
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            bool user = SecureManager.VerifyUser(username, password);

            if (user == true)
            {
                Console.WriteLine($"You logged in as {username}");
                return true;
            }
            else
            {
                Console.WriteLine("You typed the wrong password, try again");
                return false;
            }
        }

        static string StartMenu()
        {
            Console.WriteLine("" +
                "\n1: Create User" +
                "\n2: Log in");

            return Console.ReadLine();
        }

        static void CreateUser()
        {
            string username, password;
            Credentials(out username, out password);

            SecureManager.CreateUser(username, password);

            Console.WriteLine("Bruger oprettet");
        }

        private static void Credentials(out string username, out string password)
        {
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            Console.WriteLine("Enter password");
            password = Console.ReadLine();
        }
    }
}

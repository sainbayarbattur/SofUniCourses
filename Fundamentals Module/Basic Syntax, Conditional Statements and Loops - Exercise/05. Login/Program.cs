using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp60
{
    class Program
    {
        static void Main(string[] args)
        {
            string User = Console.ReadLine();
            string password = "";
            int L = User.Length;
            string testpass = "";

            for (int i = L - 1; i >= 0; i--)
            {
                password += User[i];
            }

            int temp = 0;
            while (testpass != password)
            {
                testpass = Console.ReadLine();

                if (testpass == password)
                {
                    Console.WriteLine($"User {User} logged in.");
                    break;
                }

                if (testpass != password)
                {
                    temp++;
                    if (temp <= 3)
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                    else
                    {
                        Console.WriteLine($"User {User} blocked!");
                        break;
                    }
                }
            }

            Console.Read();
        }
    }
}

//UWNetID: chrisd94
//Name:    Christopher Davenport
//Class CSHP320 A Sp 21: Creating Client Applications Using .Net Core
//Homework 2



using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Exercise #1 - Display to the console, the names of the users where the password is "hello".
            Console.WriteLine("The following users have the password Hello");
            int count = 0;

            foreach (var user in users)
            {
                count++;
                if (user.Password == "hello")
                {
                    Console.WriteLine(user.Name);
                }
            }
           
            Console.WriteLine("");

            //Exercise #2 - Delete any passwords that are the lower-cased version of their Name
            users.RemoveAll(s => s.Password == s.Name.ToLowerInvariant());
            Console.WriteLine("Removing Users where password is lowercase name");
            Console.WriteLine("The following users are left after deletion");
            count = 0;
            foreach (var user in users)
            {
                count++;
                
                Console.WriteLine(user.Name);
                    
            }

            //Exercise #3 - Delete the first User that has the password "hello"
            Console.WriteLine("");
            Console.WriteLine("Removing the first user wholse password is hello");
            var hello = users.Where(s => s.Password == "hello").FirstOrDefault();
            if (hello != null)
            {
                users.Remove(hello);
            }

            count = 0;
            foreach (var user in users)
            {
                count++;
                Console.WriteLine(user.Name + " is the remaining user. Password: " + user.Password);

            }




        }

    }
}

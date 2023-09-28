using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! Would you like to generate a random activity? yes/no: ");
            string userInput1 = Console.ReadLine();
            bool cont = userInput1.ToLower() == "yes";

            if (!cont)
            {
                Console.WriteLine("Goodbye!");
                return; // Stop the program
            }

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge;

            // Validate user input for age
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Please enter a valid age: ");
            }
            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string userInput2 = Console.ReadLine();
            bool seeList = userInput2.ToLower() == "sure";

            if (seeList)
            {
                Console.WriteLine("Current list of activities:");

                foreach (string activity in activities)
                {
                    Console.WriteLine(activity);
                    Thread.Sleep(250);
                }

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string userInput3 = Console.ReadLine();
                bool addToList = userInput3.ToLower() == "yes";

                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    Console.WriteLine("Updated list of activities:");

                    foreach (string activity in activities)
                    {
                        Console.WriteLine(activity);
                        Thread.Sleep(250);
                    }

                    Console.Write("Would you like to add more? yes/no: ");
                    string userInput4 = Console.ReadLine();
                    addToList = userInput4.ToLower() == "yes";
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge <= 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    if (activities.Count == 0)
                    {
                        Console.WriteLine("No more activities left.");
                        break;
                    }
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                cont = Console.ReadLine().ToLower() == "redo";
            }
        }
    }
}
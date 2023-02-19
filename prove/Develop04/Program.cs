using System;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine();
            Thread.Sleep(2000);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1 - Breathing");
                Console.WriteLine("2 - Reflection");
                Console.WriteLine("3 - Listing");
                Console.WriteLine("0 - Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                }
                else if (choice == "2")
                {
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                }
                else if (choice == "3")
                {
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }

            Console.WriteLine("Thank you for using the Mindfulness App!");
        }
    }
}
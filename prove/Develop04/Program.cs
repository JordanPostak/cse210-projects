
// Import required libraries
using System;
using System.Threading;
using System.Collections.Generic;

// -------------------------------------------------------------------------------------------------------------
// This Program exceeds core requirements in the following ways:

//  - I added a hold in between the breath in and breath out. My wife is a pilates instructor and suggested it.
//  - I added count down numbers on each of the breathing steps so the user can see how long the step is for.
//  - In the ListingActivity I added a list of questions to ask  the user about the items after the activity.
//  - I made sure that when the time is up, the program will finish a cycle of the activity. for example in the  breathing activity, it will finish all three steps if the time runs out in the middle of the process.
//  - I through a fail safe in when prompting for the duration to ensure it is a positive integer value.
// -------------------------------------------------------------------------------------------------------------

// Define the namespace for the program
namespace MindfulnessApp
{
    // Define the main program class
    public class Program
    {
        // Define class variables
        protected int _duration = 0; // Duration of the activity (in seconds)
        protected string _activity = ""; // Name of the activity
        protected string _description = ""; // Description of the activity

        // Main function
        static void Main(string[] args)
        {
            // Clear console and welcome the user
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine();
            Thread.Sleep(2000);

            // Loop through the menu until the user chooses to exit
            while (true)
            {
                // Display the menu options to the user
                Console.Clear();
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1 - Breathing");
                Console.WriteLine("2 - Reflection");
                Console.WriteLine("3 - Listing");
                Console.WriteLine("0 - Exit");

                // Get the user's choice
                string choice = Console.ReadLine();

                // Run the appropriate activity based on the user's choice
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
                    // Exit the program if the user chooses to do so
                    break;
                }
                else
                {
                    // Display an error message if the user enters an invalid choice
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }

            // Display a goodbye message to the user
            Console.WriteLine("Thank you for using the Mindfulness App!");
        }

        // Function to begin an activity
        protected void BeginActivity(string activity, string description)
    {
        // Show starting message to the user
        ShowStartingMessage(activity);
        // Show description of the activity to the user
        ActivityDescription(activity, description);
        // Get the duration of the activity from the user
        GetDuration(activity);
        // Display a "get ready" message to the user
        GetReady();
    }

    // Function to show the description of an activity to the user
    protected void ActivityDescription(string activity, string description)
    {
        // Clear the console and display a "well done" message to the user
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"The {activity} Activity is designed to {description}");
        Console.WriteLine();
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }

    // Function to finish an activity
    protected void FinishingActivity(string activity, int duration)
    {
        // Clear the console and display a "well done" message to the user
        Console.Clear();
        WellDone();
        Console.WriteLine();
        // Display the duration of the activity to the user
        ShowFinishingMessage(activity, duration);
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }

    // Function to show a starting message to the user
    protected void ShowStartingMessage(string activity)
    {
        // Clear the console and display a welcome message to the user
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {activity} activity!");
        Console.WriteLine();
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }

    // ShowFinishingMessage displays a message to the user when the activity is completed, including the name of the activity and the duration in seconds.
    protected void ShowFinishingMessage(string activity, int duration)
    {
        Console.WriteLine();
        Console.WriteLine($"You have completed the {activity} activity in {duration} seconds!");
        Console.WriteLine();
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }

    // ShowSpinner displays a spinner animation on the console for a specified number of milliseconds. The spinner consists of four characters that rotate in a loop.
    protected static void ShowSpinner(int milliseconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        int currentSpinnerIndex = 0;
        int spinnerDelay = 100; // Delay between spinner frames in milliseconds

        int elapsedMilliseconds = 0;
        while (elapsedMilliseconds < milliseconds)
        {
            Console.Write(spinner[currentSpinnerIndex]);
            Thread.Sleep(spinnerDelay);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // Move cursor back to overwrite previous character
            currentSpinnerIndex = (currentSpinnerIndex + 1) % spinner.Length;
            elapsedMilliseconds += spinnerDelay;
        }
        Console.WriteLine();
    }

    // GetReady displays a message to the user to get ready for the activity, and displays a spinner animation for five seconds to build anticipation.
    protected void GetReady()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(5000);
    }

    // WellDone displays a message to the user when the activity is completed successfully.
    protected void WellDone()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Thread.Sleep(2000);
    }

    // GetDuration prompts the user to enter the desired duration of the activity in seconds, and validates the input to ensure it is a positive integer value. It returns the validated duration value.
    protected int GetDuration(string activity)
    {
        while (_duration <= 0)
        {
            Console.Clear();
            Console.WriteLine($"How long would you like your {activity} session to be?");
            Console.WriteLine();
            Console.Write("Enter duration (in seconds) then press Enter > ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"You have selected a {_duration} second session.");
                Console.WriteLine();
                Console.Write("Press Enter > ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a valid positive integer value for the duration.");
                Console.WriteLine();
                Console.Write("Press Enter > ");
                Console.ReadKey();
            }
        }
        return _duration;
    }
    }
} 
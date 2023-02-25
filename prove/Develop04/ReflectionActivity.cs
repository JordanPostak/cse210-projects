using System;
using System.Collections.Generic;
using System.Threading;

// the namespace for the program
namespace MindfulnessApp
{
public class ReflectionActivity : Program
{
    // Private member variables (uniaque to the class) to store prompts, questions, and end time
    private List<string> _prompts;
    private List<string> _questions;
    private DateTime _endTime;

    // Constructor to initialize the prompts and questions lists
    public ReflectionActivity()
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?"
        };
    }

    // Method (unique to the class) to randomly select a prompt and display it to the user
    public void randomreflect()
    {
        // Get the duration of the activity from the base class
        int duration = base._duration;

        // Select a random prompt from the prompts list and display it to the user
        Random rand = new Random();

        // Select a random prompt from the prompts list and display it to the user
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"Consider the following prompt:\n\n{prompt}\n");
        Console.WriteLine("When you have something in mind press enter to continue.");
        Console.ReadLine();

        // Set the end time of the activity based on the duration
        _endTime = DateTime.Now.AddSeconds(duration);

        // Loop until the end time is reached
        while (DateTime.Now < _endTime)
        {
            // Select a random question from the questions list and display it to the user
            int randomIndex = rand.Next(_questions.Count);
            string randomQuestion = _questions[randomIndex];
            Console.Write($"{randomQuestion}  ");

            // Call the ShowSpinner method to display a spinner animation for 10 seconds
            ShowSpinner(10000);
        }
    }

    // Method to run the activity
    public void Run()
    {
        // Call the BeginActivity method to display the activity name and description
        BeginActivity("Reflection", "help you reflect on positive experiences in your life.");

        // Call the randomreflect method to begin the activity
        randomreflect();

        // Call the FinishingActivity method to display the activity completion message
        FinishingActivity("Reflection", GetDuration(_activity));
    }

}
}
using System;
using System.Collections.Generic;

// the namespace for the program
namespace MindfulnessApp
{
public class ListingActivity : Program
{
    // Private member variables (uniaque to the class) to store prompts, questions, and end time
    private List<string> _prompts;// A list of prompts to choose from
    private List<string> _questions;// A list of questions to ask after the activity
    private List<string> _items;// A list to store the items the user lists
    
    // Constructor to initialize the prompts, questions and items lists
    public ListingActivity()
    {
        // Initialize the prompts, questions, and items lists
        _prompts = new List<string>()
        {
            "List as many things as you can that you are grateful for in your life.",
            "List as many things as you can that make you happy.",
            "List as many things as you can that you have accomplished in the past year.",
            "List as many things as you can that you love about yourself.",
            "List as many things as you can that you are looking forward to in the future."
        };
        _questions = new List<string>()
        {
            "Why are you grateful for these things?",
            "What makes these things so special to you?",
            "How do these things impact your life?",
            "What would your life be like without these things?",
            "What can you do to show appreciation for these things?"
        };
        _items = new List<string>();
    } 

    //Method (unique to the class) for listing the items.
    private void Listit()
    {
        // Get the duration of the activity from the base class
        int duration = base._duration;

        // Choose a random prompt from the list
        string prompt = _prompts[new Random().Next(_prompts.Count)];

        Console.WriteLine(prompt);
        Console.WriteLine("> Start typing and press enter after each item:");

        // Set the end time for the activity
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Loop until the end time is reached
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();

            // Add the item to the list
            _items.Add(item);
        }

        // Display the number of items the user listed
        Console.WriteLine("You listed {0} items!", _items.Count);

        // Choose a random question from the list
        string question = _questions[new Random().Next(_questions.Count)];

        Console.WriteLine(question);
        Console.ReadLine();
    }

    // Method to run the activity
    public void Run()
    {
        // Call the BeginActivity method to display the activity name and description
        BeginActivity("Listing", "help you focus on the good things in life by having you list as many items as you wish.");

        // Call the Listit method to begin the activity
        Listit();

        // Call the FinishingActivity method to display the activity completion message
        FinishingActivity("Listing", GetDuration(_activity));
    }
}
}
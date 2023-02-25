using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
public class ListingActivity : Activity
{
    private List<string> prompts;
    private List<string> questions;
    private List<string> items;
    public ListingActivity()
    {
        prompts = new List<string>()
        {
            "List as many things as you can that you are grateful for in your life.",
            "List as many things as you can that make you happy.",
            "List as many things as you can that you have accomplished in the past year.",
            "List as many things as you can that you love about yourself.",
            "List as many things as you can that you are looking forward to in the future."
        };
        questions = new List<string>()
        {
            "Why are you grateful for this thing?",
            "What makes this thing so special to you?",
            "How does this thing impact your life?",
            "What would your life be like without this thing?",
            "What can you do to show appreciation for this thing?"
        };
        items = new List<string>();
    } 

    private void Listit()
    {
        // Choose a random prompt from the list
        string prompt = prompts[new Random().Next(prompts.Count)];

        Console.WriteLine(prompt);
        Console.WriteLine("> Start typing and press enter after each item:");

        // Set the end time for the activity
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        // Loop until the end time is reached
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();

            // Add the item to the list
            items.Add(item);
        }

        // Display the number of items the user listed
        Console.WriteLine("You listed {0} items!", items.Count);

        // Choose a random question from the list
        string question = questions[new Random().Next(questions.Count)];

        Console.WriteLine(question);
        Console.ReadLine();
    }

    public void Run()
    {
        int duration = base.duration;
        BeginActivity("Listing", "help you focus on the good things in life by having you list as many items as you wish.");
        Listit();
        FinishingActivity("Listing", GetDuration(activity));
    }
}
}
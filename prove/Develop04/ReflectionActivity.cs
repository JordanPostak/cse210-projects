using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
public class ReflectionActivity : Activity
{
    private List<string> prompts;
    private List<string> questions;
    private List<string> items;
    private DateTime endTime;

    public ReflectionActivity()
    {
        prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?"
        };
        items = new List<string>();
    }

    public void randomreflect()
    {
        int duration = base.duration;
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"Consider the following prompt:\n\n{prompt}\n");
        Console.WriteLine("When you have something in mind press enter to continue.");
        Console.ReadLine();


        endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            int randomIndex = rand.Next(questions.Count);
            string randomQuestion = questions[randomIndex];
            Console.Write($"{randomQuestion}  ");
            ShowSpinner(10000);
        }
    }

    public void Run()
    {
        BeginActivity("Reflection", "help you reflect on positive experiences in your life.");
        randomreflect();
        FinishingActivity("Reflection", GetDuration(activity));
    }

}
}
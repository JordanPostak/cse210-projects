using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    protected int duration = 0;
    protected string activity = "";
    protected string description = "";

    protected void BeginActivity(string activity, string description)
    {
        ShowStartingMessage(activity);
        ActivityDescription(activity, description);
        GetDuration(activity);
        GetReady();
    }

    protected void ActivityDescription(string activity, string description)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"The {activity} Activity is designed to {description}");
        Console.WriteLine();
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }
    protected void FinishingActivity(string activity, int duration)
    {
        Console.Clear();
        WellDone();
        Console.WriteLine();
        ShowFinishingMessage(activity, duration);
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }

    protected void ShowStartingMessage(string activity)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {activity} activity!");
        Console.WriteLine();
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }

    protected void ShowFinishingMessage(string activity, int duration)
    {
        Console.WriteLine();
        Console.WriteLine($"You have completed the {activity} activity in {duration} seconds!");
        Console.WriteLine();
        Console.Write("Press Enter > ");
        Console.ReadKey();
    }

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

    protected void GetReady()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(5000);
    }

    protected void WellDone()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Thread.Sleep(2000);
    }

    protected int GetDuration(string activity)
{
    while (duration <= 0)
    {
        Console.Clear();
        Console.WriteLine($"How long would you like your {activity} session to be?");
        Console.WriteLine();
        Console.Write("Enter duration (in seconds) then press Enter > ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out duration) && duration > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"You have selected a {duration} second.");
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
    return duration;
}

}
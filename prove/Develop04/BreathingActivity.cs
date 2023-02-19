class BreathingActivity : Activity
{
    
    private void CountdownBreath(int duration)
    {
        const int countdownDuration = 5; // 5 seconds
        const int Delay = 1000; // 1 second
        int remainingDuration = duration;

        Console.Clear();
        while (remainingDuration > 0)
        {
            for (int i = 0; i < 3; i++) // Run the loop three times for "Breath in", "Hold Breath" and "Breath out"
            {
                string message;

                switch (i)
                {
                    case 0:
                        message = "Breath in...";
                        break;
                    case 1:
                        message = "Hold...";
                        break;
                    case 2:
                        message = "Breath out...";
                        break;
                    default:
                        message = "";
                        break;
                }

                Console.Write($"{message} ");
                for (int j = countdownDuration; j >= 1; j--)
                {
                    Console.Write($"{j} ");
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop); // Move the cursor back to the previous number position
                    Thread.Sleep(Delay);
                }
                Console.WriteLine();

                Console.Clear(); // Clear the console after each breathing phase
            }

            remainingDuration -= countdownDuration * 3; // Subtract the duration of three breathing phases
        }
    }

    public void Run()
    {
        BeginActivity("Breathing", "help you relax and focus.");
        CountdownBreath(duration);
        FinishingActivity("Breathing", GetDuration(activity));
    }
}
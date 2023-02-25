// the namespace for the program
namespace MindfulnessApp
{

    
public class BreathingActivity : Program
{
    //Method (unique to the class) for the breathing activity.
    private void CountdownBreath(int duration)
    {
        // The duration of each countdown (in seconds)
        const int countdownDuration = 5; 

        // The delay between each number (in milliseconds)
        const int Delay = 1000; 
        int remainingDuration = duration;

        // Clear the console at the beginning of the countdown
        Console.Clear(); 

        // Keep running the countdown until the total duration has elapsed
        while (remainingDuration > 0) 
        {
            // Run the loop three times for "Breath in", "Hold" and "Breath out"
            for (int i = 0; i < 3; i++)
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

                // Display the breathing phase message (e.g. "Breath in...")
                Console.Write($"{message} ");
                for (int j = countdownDuration; j >= 1; j--)
                {
                    // Display the countdown numbers (e.g. "5 4 3 2 1")
                    Console.Write($"{j} ");

                    // Move the cursor back to the previous number position to overwrite it with the next number
                    Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);

                    // Wait for the delay before displaying the next number
                    Thread.Sleep(Delay);
                }
                // Move to the next line after the countdown is finished
                Console.WriteLine();

                // Clear the console after each breathing phase
                Console.Clear();
            }

            // Subtract the duration of three breathing phases from the total duration
            remainingDuration -= countdownDuration * 3; 
        }
    }

    // Method to run the activity
    public void Run()
    {
        // Call the BeginActivity method to display the activity name and description
        BeginActivity("Breathing", "help you relax and focus.");

        // Call the CountdownBreath method to begin the activity
        CountdownBreath(_duration);

        // Call the FinishingActivity method to display the activity completion message
        FinishingActivity("Breathing", GetDuration(_activity));
    }
}
} 
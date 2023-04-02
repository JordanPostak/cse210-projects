using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace InspireStone
{
    public class Program 
    {
        // Attributes
        static protected List<string> _typeList = new List<string>() { "Pearl", "Task", "Mission", "Habit" };
        static protected List<string> _positiveList = new List<string>();
        static protected List<string> _feelList = new List<string>();
        static protected int _luminosity = 0;
        static protected List<string> _inspireList = new List<string>();
        static protected string _select = "";
        static protected int _step = 0;
        static protected string _inspire = "";
        static protected string _name = "";
        static protected string _feel = "";
        static protected string _type = "";
        static protected string _script = "";
        static protected string _word = "";
        static protected string _plan = "";
        static protected string _link = "";
        static protected string _act = "";
        static protected string _review = "";
        static protected string _record = "";
        static protected int _index = -1;

        // The Main method initializes the program by setting the console color, loading feelings and positive words, loading inspirations from a file, and calling the Menu method.
        static void Main(string[] args)
        {
           
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Program program = new Program();
            Console.WriteLine();
            Console.WriteLine();
            TypingEffect("Welcome to Inspire Stone!");
            Console.WriteLine();

            Feelings.LoadFeelings();
            Listen.LoadPositives();
            // Load inspirations from file
            Inspire.InspireList();
            program.Menu();
        }

        // The Menu method displays the main menu options and waits for the user to select an option. Based on the user's input, it either calls one of the subprograms (Listen, Receive, Ponder, Plan, Act, Review, Record, or Journal), or saves the list of inspirations and quits the program. It uses a while loop to continue displaying the main menu until the user selects the option to quit.
        protected virtual void Menu()
        {

            // Main menu
            bool quit = false;
            while (!quit)
            {
                Inspire.DisplayLuminosity();
                TypingEffect("Please Select from the choices below:");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Brows Inspirations");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2. Listen");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("3. Receive");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("4. Ponder");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("5. Plan");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("6. Act");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("7. Review");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("8. Record");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("9. Journal");
                Console.WriteLine("10. Quit");
                Console.WriteLine();
                BlinkIndicator();


                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        InspireSelect();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypingEffect("Get ready to Listen...");
                        ShowSpinner();
                        Listen listen = new Listen();
                        listen.Run();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "3":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        TypingEffect("Get ready to Receive...");
                        ShowSpinner();
                        Recieve recieve = new Recieve();
                        recieve.Run();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        TypingEffect("Get ready to Ponder...");
                        ShowSpinner();
                        Ponder ponder = new Ponder();
                        ponder.Run();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "5":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        TypingEffect("Get ready to Plan...");
                        ShowSpinner();
                        Plan plan = new Plan();
                        plan.Run();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "6":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        TypingEffect("Get ready to Act...");
                        ShowSpinner();
                        Act act = new Act();
                        act.Run();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "7":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        TypingEffect("Get ready to Review...");
                        ShowSpinner();
                        Review review = new Review();
                        review.Run();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "8":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;TypingEffect("Get ready to Record...");
                        ShowSpinner();
                        Record record = new Record();
                        record.Run();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "9":
                        Console.Clear();
                        Journal.ViewJournal();
                        break;
                    case "10":
                        Inspire.SaveInspireList();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;TypingEffect("Have a nice day...");
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }
        
        // This method adds a new inspiration to the inspiration list, if it is not already in the list. If the new inspiration is already in the list, it displays a message indicating so.
        protected virtual void AddInspire()
        {
            string newInspiration = "";
            // Check if the new inspiration is not already in the list
            if (!_inspireList.Contains(newInspiration))
            {
                // Add the new inspiration to the list
                _inspireList.Add(newInspiration);
                Console.WriteLine($"Added '{newInspiration}' to the inspiration list.");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine($"'{newInspiration}' is already in the inspiration list.");
                Thread.Sleep(2000);
            }
        }

        // This method prompts the user to select an inspiration from the inspiration list. If there are no inspirations in the list, it displays a message indicating so and returns the user to the main menu. It also checks that the user's input is valid and within the range of available inspirations before setting the selected inspiration.
        protected virtual void InspireSelect()
        {
            Console.Clear();

            if (_inspireList.Count == 0)
            {
                Console.WriteLine("There are no inspirations to brows.");
                Console.WriteLine("\nPress enter to return to the main menu.");
                Console.ReadLine();
                Console.Clear();
                Menu();
            }

            TypingEffect("\nSelect an inspiration:");
            Console.WriteLine();
            for (int i = 0; i < _inspireList.Count; i++)
            {
                string[] parts = _inspireList[i].Split(new string[] { "///" }, StringSplitOptions.None);
                Console.WriteLine($"{i + 1}. {parts[2]}");
            }
            Console.WriteLine();
            BlinkIndicator();

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int selection))
            {
                // Check if selection is within range
                if (selection > 0 && selection <= _inspireList.Count)
                {
                    _index = selection - 1;
                    _select = _inspireList[_index];
                    _step = 1;
                    Inspire.InspireSeperate();
                    Inspire.DisplayInspiration();
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }

            Console.WriteLine("\nPress enter to return to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        // This method increments the _step variable by one.
        static public void StepUpgrade()
        {
            // adds one to _step
            _step++;
        } 

        // This method creates a typing effect by printing a string to the console character by character, with a delay between each character.
        protected static void TypingEffect(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        // This method creates a blinking indicator on the console by alternating between displaying and hiding the ">>>" string, until a key is pressed.
        protected static void BlinkIndicator()
        {
            string message = ">>>";
            bool visible = true;

            while (!Console.KeyAvailable)
            {
                if (visible)
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        Console.Write(message[i]);
                        Thread.Sleep(250);
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', message.Length));
                    Console.SetCursorPosition(0, Console.CursorTop);
        
                }
                visible = !visible;
                Thread.Sleep(250);
            }
        }

        // This method displays a spinner animation for 2 seconds using an array of spinner frames. It prints the frames to the console and uses a variable to track the current frame index, which increments and resets using the modulus operator. It pauses for 100 milliseconds between each frame using Thread.Sleep.
        private static void ShowSpinner()
        {
            string[] spinners = new string[] { "/", "-", "\\", "|" };
            int spinnerIndex = 0;

            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 2)
            {
                Console.Write($"\r{spinners[spinnerIndex]}");
                spinnerIndex = (spinnerIndex + 1) % spinners.Length;
                Thread.Sleep(100);
            }
        }
    }
}
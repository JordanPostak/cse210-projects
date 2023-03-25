using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    public class Program 
    {
        // Attributes
        protected List<string> _typeList = new List<string>() { "Pearl", "Task", "Mission", "Habit" };
        protected List<string> _positiveList = new List<string>() {};
        protected List<string> _feelList = new List<string>() { "Joy", "Love", "Gratitude", "Peace", "Hope", "Excitement", "Happiness", "Satisfaction", "Contentment" };
        protected int _luminosity = 0;
        protected List<string> _inspireList = new List<string>();
        protected string _select = "";
        protected int _step = 0;
        protected string _inspire = "";
        protected string _name = "";
        protected string _feel = "";
        protected string _type = "";
        protected string _script = "";
        protected string _word = "";
        protected string _plan = "";
        protected string _link = "";
        protected string _act = "";
        protected string _review = "";
        protected string _record = "";
        protected int _index = -1;

        // Behaviors
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Welcome to Inspire Stone!");

            // Load inspirations from file
            program.InspireList();

            // Display luminosity score
            Console.WriteLine($"Your luminosity score is: {program._luminosity}");

            // Main menu
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Browse inspirations");
                Console.WriteLine("2. Listen");
                Console.WriteLine("3. Receive");
                Console.WriteLine("4. Ponder");
                Console.WriteLine("5. Plan");
                Console.WriteLine("6. Act");
                Console.WriteLine("7. Review");
                Console.WriteLine("8. Record");
                Console.WriteLine("9. Journal");
                Console.WriteLine("10. Quit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        program.InspireSelect();
                        break;
                    case "2":
                        Console.WriteLine("Get ready to Listen...");
                        Listen listen = new Listen();
                        listen.Run();
                        break;
                    case "3":
                        Console.WriteLine("Get ready to Receive...");
                        Recieve recieve = new Recieve();
                        recieve.Run();
                        break;
                    case "4":
                        Console.WriteLine("Get ready to Ponder...");
                        Ponder ponder = new Ponder();
                        ponder.Run();
                        break;
                    case "5":
                        Console.WriteLine("Get ready to Plan...");
                        Plan plan = new Plan();
                        plan.Run();
                        break;
                    case "6":
                        Console.WriteLine("Get ready to Act...");
                        Act act = new Act();
                        act.Run();
                        break;
                    case "7":
                        Console.WriteLine("Get ready to Review...");
                        Review review = new Review();
                        review.Run();
                        break;
                    case "8":
                        Console.WriteLine("Get ready to Record...");
                        Record record = new Record();
                        record.Run();
                        break;
                    case "9":
                        program.ViewJournal();
                        break;
                    case "10":
                        program.SaveInspireList();
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        protected void SaveInspireList()
        {
            // Open file for writing
            using (StreamWriter file = new StreamWriter("inspirelist.txt"))
            {
                // Write luminosity to the first line of the file
                file.WriteLine(_luminosity);

                // Write each item in inspireList to a new line in the file
                foreach (string item in _inspireList)
                {
                    file.WriteLine(item);
                }
            }
        }
        protected virtual void AddInspire() //(overridden by some child classes)
        {
            //Adds an inspiration to the inspiration list.
        }

        // Load luminosity score and inspirations from inspirelist.txt and sets them to luminosity and _inspireList.
        protected void InspireList()
        {
            if (File.Exists("inspirelist.txt"))
            {
                string[] lines = File.ReadAllLines("inspireList.txt");
                
                // Add the first line to luminosity int
                if (Int32.TryParse(lines[0], out int lum))
                {
                    _luminosity = lum;
                }
                
                // Add the rest of the lines to _inspireList
                for (int i = 1; i < lines.Length; i++)
                {
                    _inspireList.Add(lines[i]);
                }
            }
        }

        // Prompt user to select an inspiration
        protected virtual void InspireSelect()
        {
            Console.WriteLine("\nSelect an inspiration:");
            for (int i = 0; i < _inspireList.Count; i++)
            {
                string[] parts = _inspireList[i].Split(new string[] { "///" }, StringSplitOptions.None);
                Console.WriteLine($"{i + 1}. {parts[2]}");
            }

            string input = Console.ReadLine();
            int selection;
            if (Int32.TryParse(input, out selection))
            {
                // Check if selection is within range
                if (selection > 0 && selection <= _inspireList.Count)
                {
                    _index = selection - 1;
                    _select = _inspireList[_index];
                    _step = 1;
                    Console.WriteLine($"Selected inspiration: {_select}");
                    // Split selected inspiration by "///" and print each part on a new line
                    string[] parts = _select.Split(new string[] { "///" }, StringSplitOptions.None);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        Console.WriteLine(parts[i]);
                    }
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
        }

        // InspireSeperate(): takes _select and separates it by the “///” and separates them into the different parts variables; _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review.
        protected void InspireSeperate() //(overridden by some child classes)
        {
            //Adds an inspiration to the inspiration list.
        }

        // Display journal entries
        protected void ViewJournal()
        {
            Console.WriteLine("\nJournal Entries:");
            if (File.Exists("journal.txt"))
            {
                string[] entries = File.ReadAllLines("journal.txt");
                foreach (string entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("No journal entries found.");
            }
        }

        // Save user input to journal file
        protected void SaveToJournal(string entry)
        {
            using (StreamWriter writer = File.AppendText("journal.txt"))
            {
                writer.WriteLine(entry);
            }
        }

        protected void GetIndex()
        {
            // gets index of _select in _inspireList and sets it to _index.
        }

        // Save selected inspiration to index file
        protected void SaveToIndex()
        {
            if (_index != -1)
            {
                using (StreamWriter writer = File.AppendText("index.txt"))
                {
                    writer.WriteLine(_select);
                }
                Console.WriteLine("Selected inspiration saved to index.");
            }
        }
    }
}
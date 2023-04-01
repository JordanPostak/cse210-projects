using System;
using System.Collections.Generic;
using System.IO;
using InspireStone;

    public class Journal: Program
    {
        static string _currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        // Display journal entries
        static public void ViewJournal()
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

        static public void SaveInspaDataToJournal()
        {
            // calls InspireSeperate();
            Inspire.InspireSeperate();

            // Create a StreamWriter object to write to the journal.txt file
            using (StreamWriter writer = new StreamWriter("journal.txt", true))
            {

                writer.WriteLine();
                writer.WriteLine($"-------On {_currentDate}, the inspiration {_name} was recorded.-------");
                // Inspiration Name: (_name)
                writer.WriteLine("Inspiration Name:");
                writer.WriteLine($"{_name}");

                // Type of Inspiration: (_type)
                writer.WriteLine("Type of Inspiration:");
                writer.WriteLine($"{_type}");

                // Inspiration Text: (_inspire)
                writer.WriteLine("Inspiration Text:");
                writer.WriteLine($"{_inspire}");

                // Associated Feeling: (_feel)
                writer.WriteLine("Associated Feeling:");
                writer.WriteLine($"{_feel}");

                // (Only write if _script is not Undefined) Scriptural Support: (_script)
                if (_script != "Undefined")
                {
                    writer.WriteLine("Scriptural Support:");
                    writer.WriteLine($"{_script}");
                }

                // (Only write if _word is not Undefined) Prophetic Support: (_word)
                if (_word != "Undefined")
                {
                    writer.WriteLine("Prophetic Support:");
                    writer.WriteLine($"{_word}");
                }

                // (Only write if _plan is not Undefined) Plan of Action: (_plan)
                if (_plan != "Undefined")
                {
                    writer.WriteLine("Plan of Action was:");
                    writer.WriteLine($"{_plan}");
                }

                // (Only write if _link is not Undefined) Child of: (_link)
                if (_link != "Undefined")
                {
                    writer.WriteLine($"Was a Sub-{_type} of:");
                    writer.WriteLine($"{_link}");
                }

                // (Only write if _act is not Undefined) Action: (_act)
                if (_act != "Undefined")
                {
                    writer.WriteLine("Acted on Inspiration:");
                    writer.WriteLine($"{_act}");
                }

                // (Only show if _review is not Undefined) Review: (_review)
                if (_review != "Undefined")
                {
                    writer.WriteLine("Reviewed with the Creator:");
                    writer.WriteLine($"{_review}");
                }
            }
        }

        // Save user input to journal file
        static public void SaveToJournal(string entry)
        {
            using (StreamWriter writer = File.AppendText("journal.txt"))
            {
                writer.WriteLine("Journal Entry:");
                writer.WriteLine($"{entry}");
            }
        }
    }

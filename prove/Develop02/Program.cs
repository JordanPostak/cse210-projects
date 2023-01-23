using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// This program exceeds requirements with the use of JSON for storage
// This program exceeds requirements by adding in an option for the user to have a prompt randomly selected or to choose their own prompt from a list.
// This program exceeds requirements with the addition of color coding!

namespace Develop02
{
    class Program
    {
        // Declare a static journal object and a variable to store the current file name
        static Journal journal = new Journal();
        static string currentFile;

        static void Main(string[] args)
        {
            // Continuously display the menu and execute the chosen option
            while (true)
            {
                // Display the menu options to the user
                DisplayMenu();

                // Get the user's chosen option
                int option = GetOption();

                switch (option)
                {
                    case 1:
                        LoadJournal();
                        break;
                    case 2:
                        DisplayJournal();
                        break;
                    case 3:
                        AddEntry();
                        break;
                    case 4:
                        SaveJournal();
                        break;
                    case 5:
                        Exit();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // DisplayMenu() method displays the main menu of the journal app.
        // It shows the current journal file being used and the options available to the user.
        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Journal App");
            Console.WriteLine("Current journal: " + currentFile);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Load journal");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Add entry");
            Console.WriteLine("4. Save journal as...");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
        }

        // GetOption() method prompts the user to enter an option from the main menu
        // and validates the input to make sure it is a number between 1 and 5.
        // It returns the valid option entered by the user.
        static int GetOption()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter option: ");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
            return option;
        }

        // LoadJournal() method prompts the user to enter the name of a journal file
        // and loads the journal from that file if it exists and is not empty.
        // If the file does not exist or is empty, an error message is displayed.
        // This program exceeds requirments with the use of JSON for storage
        static void LoadJournal()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            currentFile = fileName;

            if (!File.Exists(fileName))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The journal file does not exist.");
                return;
            }

            string json = File.ReadAllText(fileName);
            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The journal file is empty.");
                return;
            }

            journal = JsonSerializer.Deserialize<Journal>(json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Journal Loaded!");
        }

        // AddEntry() method prompts the user to choose whether they would like to choose their own prompt or have one randomly selected.
        // This is one of the ways this program exceed requirements
        // If the user chooses to select their own prompt, it gets the prompt from the Entry class, displays it to the user,
        // prompts the user to enter a response, and creates a new entry with the prompt, response, and the current date and time.
        // If the user chooses to have a prompt randomly selected, the prompt is chosen from the predefined list of prompts in the Entry class.
        // The new entry is added to the journal and the journal is saved.
        static void AddEntry()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string prompt;
            Console.WriteLine("Would you like to choose your own question? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
            prompt = Entry.GetPrompt();
            }
            else
            {
            Random rand = new Random();
            int index = rand.Next(0, Entry.prompts.Count);
            prompt = Entry.prompts[index];
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Prompt: " + prompt);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter response: ");
            string response = Console.ReadLine();
            DateTime date = DateTime.Now;
            journal.AddEntry(prompt, response, date);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Entry saved to "+ currentFile);
            JournalHelper.SaveJournal(journal, currentFile);
        }

        // DisplayJournal() method displays the current journal file to the user.
        // If the current file does not exist or is empty, an error message is displayed.
        // This program exceeds requirments with the use of JSON for storage
        static void DisplayJournal()
        {
            string fileName = currentFile;
            if (!File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The journal file does not exist.");
                return;
            }

            string json = File.ReadAllText(fileName);
            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The journal file is empty.");
                return;
            }

            journal = JsonSerializer.Deserialize<Journal>(json);
            journal.DisplayEntries();
        }

        // SaveJournal() method prompts the user to enter a file name and saves the current journal to that file.
        // It then displays a message indicating that the journal has been saved to the specified file.
        static void SaveJournal()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            currentFile = fileName;

            string json = JsonSerializer.Serialize(journal);
            File.WriteAllText(fileName, json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Journal saved as " + fileName);
        }

        // Exit() method displays a message to the user indicating that the program is exiting,
        // sets the text color back to white, and then exits the program.
        static void Exit()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exiting...Good bye!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
    }
}
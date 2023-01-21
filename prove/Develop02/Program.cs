using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Develop02
{
    class Program
    {
        static Journal journal = new Journal();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();

                int option = GetOption();

                switch (option)
                {
                    case 1:
                        AddEntry();
                        break;
                    case 2:
                        DisplayJournal();
                        break;
                    case 3:
                        Exit();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Journal App");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Add entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
        }

        static int GetOption()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter option: ");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
            return option;
        }

        static void AddEntry()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string prompt = Entry.GetPrompt();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Prompt: " + prompt);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter response: ");
            string response = Console.ReadLine();
            DateTime date = DateTime.Now;
            journal.AddEntry(prompt, response, date);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entry recorded....");
            SaveJournal();
        }

        static void DisplayJournal()
        {
            string fileName = "journal.txt";
            if (!File.Exists(fileName))
            {
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

        static void SaveJournal()
        {
            JournalHelper.SaveJournal(journal, "journal.txt");
            Console.WriteLine();
        }

        static void Exit()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exiting...");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
    }
}
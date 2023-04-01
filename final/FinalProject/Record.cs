using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    class Record : Program
    {

        protected override void InspireSelect()
        // (overridden from Program) prompts the user to select from a list of inspirations generated by _inspireList (if _step is equal to 7. Sets the selection as _select.
        {
            bool hasInspiration = false;

            // Check if there are any inspirations with step 3
            foreach (string inspire in _inspireList)
            {
                string[] parts = inspire.Split(new string[] { "///" }, StringSplitOptions.None);
                int step;
                if (Int32.TryParse(parts[0], out step))
                {
                    if (step == 7)
                    {
                        hasInspiration = true;
                        break;
                    }
                }
            }

            if (!hasInspiration)
            {
                Console.WriteLine("There are no inspirations to record.");
                return;
            }

            Console.WriteLine("\nSelect an inspiration:");
            for (int i = 0; i < _inspireList.Count; i++)
            {
                string[] parts = _inspireList[i].Split(new string[] { "///" }, StringSplitOptions.None);
                int step;
                if (Int32.TryParse(parts[0], out step))
                {
                    if (step == 7)
                    {
                        Console.WriteLine($"{i + 1}. {parts[2]}");
                    }
                }
            }

            string input = Console.ReadLine();
            int selection;
            if (Int32.TryParse(input, out selection))
            {
                // Check if selection is within range
                bool isValidSelection = false;
                for (int i = 0; i < _inspireList.Count; i++)
                {
                    string[] parts = _inspireList[i].Split(new string[] { "///" }, StringSplitOptions.None);
                    int step;
                    if (Int32.TryParse(parts[0], out step))
                    {
                        if (step == 7 && selection == i + 1)
                        {
                            _index = i;
                            _select = _inspireList[_index];
                            Console.WriteLine($"Selected inspiration: {_select}");
                            Inspire.InspireSeperate();
                            isValidSelection = true;
                            break;
                        }
                    }
                }
                if (!isValidSelection)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }

        static public void Recording()
        {
            Journal.SaveInspaDataToJournal();
            //Prompt the user to reflect about the inspirations, instruct the user what the purpose of a journal entry is for, and who it is for, Postarity, and why it is important.
            Console.WriteLine("Please take a few moments to reflect on the inspiration and your journey with it through all the steps.");
            Console.WriteLine("Think about what it means to you and how it relates to your life. Is it important to those who come after you?");
            Console.WriteLine("Then, write a journal entry about it, explaining your thoughts and feelings.");
            // save user input
            string journalEntry = Console.ReadLine();
            Journal.SaveToJournal(journalEntry);
            // call SaveToJournal(input)
            Program.StepUpgrade();
            Inspire.SaveInspiration();
            Inspire.AddLuminosity();
            Inspire.SaveInspireList();
        }

        protected override void Menu()
        {

            while (true)
            {
                // Display luminosity score
                Inspire.DisplayLuminosity();

                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Record inspirationon");
                Console.WriteLine("2. Return to Main Menu");

                string input = Console.ReadLine();
                int selection;
                if (Int32.TryParse(input, out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            InspireSelect();
                            Recording();
                            break;
                        case 2:
                            return;
                        default:
                            Console.WriteLine("Invalid input, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            } 
        }

        public void Run()
        {
            // Implement behavior to bring up menu and initiate Record class
            Menu();
        }
    }
}
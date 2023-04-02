using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    class Review : Program
    {

        // This method prompts the user to select an inspiration from the list of inspirations with step 6. If there are no such inspirations, it informs the user and returns. If a valid selection is made, the index and selection are updated and the selected inspiration is displayed. Inherits from the Program class.
        protected override void InspireSelect()
        {
            bool hasInspiration = false;

            // Check if there are any inspirations with step 6
            foreach (string inspire in _inspireList)
            {
                string[] parts = inspire.Split(new string[] { "///" }, StringSplitOptions.None);
                int step;
                if (Int32.TryParse(parts[0], out step))
                {
                    if (step == 6)
                    {
                        hasInspiration = true;
                        break;
                    }
                }
            }

            if (!hasInspiration)
            {
                Console.WriteLine("There are no inspirations to review.");
                Thread.Sleep(2000);
                return;
            }

            TypingEffect("\nSelect an inspiration to ponder:");
            Console.WriteLine();
            for (int i = 0; i < _inspireList.Count; i++)
            {
                string[] parts = _inspireList[i].Split(new string[] { "///" }, StringSplitOptions.None);
                int step;
                if (Int32.TryParse(parts[0], out step))
                {
                    if (step == 6)
                    {
                        Console.WriteLine($"{i + 1}. {parts[2]}");
                    }
                }
            }
            Console.WriteLine();
            BlinkIndicator();

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
                        if (step == 6 && selection == i + 1)
                        {
                            _index = i;
                            _select = _inspireList[_index];
                            Inspire.InspireSeperate();
                            TypingEffect($"Selected inspiration: {_name}");
                            Thread.Sleep(2000);
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

        // This method asks the user if they have prayed and reviewed the inspiration with the Creator. If the answer is yes, it updates the review status, upgrades the step, saves the inspiration, adds luminosity, and saves the inspire list. If the answer is no, it informs the user and returns.
        public void Reviewed()
        {
            // Ask User if they have prayed and reviewed the Inspiration with the creator
            TypingEffect($"Have you prayed and reviewed the Inspiration '{_name}' with the Creator? (yes/no)");
            Console.WriteLine();
            BlinkIndicator();

            string answer = Console.ReadLine().ToLower();
            // if yes then:
            if (answer == "yes" || answer == "y" || answer == "Y")
            {
                _review = "Reviewed";
                StepUpgrade();
                Inspire.SaveInspiration();
                Inspire.AddLuminosity();
                Inspire.SaveInspireList();
            // if no then return
            }
            else if (answer == "no" || answer == "n" || answer == "N")
            {
                TypingEffect("OK, please try again later.");
                return;
                Thread.Sleep(2000);
                
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again later.");
            }
        }

        // This method selects an inspiration to review, displays it, and calls the Reviewed method to ask the user if they have reviewed it. Inherits from the Program class.
        public void Reviewing()
        {
            InspireSelect();
             if (_select == "") // check if no inspiration has been selected
            {
                return;
            }
            else
            {
                Inspire.DisplayInspiration();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Reviewed();
            }
        }

        // This method displays the review menu and prompts the user to select an option. If the user selects to review an inspiration, it calls the Reviewing method to select and display an inspiration. If the user selects to return to the main menu, it returns.
        protected override void Menu()
        {

            while (true)
            {   
                Console.Clear();
                // Display luminosity score
                Inspire.DisplayLuminosity();
                Console.WriteLine();
                Console.WriteLine("Select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Review inspiration");
                Console.WriteLine("2. Return to Main Menu");
                Console.WriteLine();
                BlinkIndicator();

                string input = Console.ReadLine();
                int selection;
                if (Int32.TryParse(input, out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            Reviewing();
                            if (_select == "") // check if no inspiration has been selected
                            {
                                return;
                            }
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

        // Run method calls the Menu method.
        public void Run()
        {
            Menu();
        }
    }
}
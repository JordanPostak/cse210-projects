using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    class Ponder : Program
    {
        // (overridden from Program) prompts the user to select from a list of inspirations generated by _inspireList (if _step equals 3). Sets the selection as _select.
        protected override void InspireSelect()
        {
            bool hasInspiration = false;

            // Check if there are any inspirations with step 3
            foreach (string inspire in _inspireList)
            {
                string[] parts = inspire.Split(new string[] { "///" }, StringSplitOptions.None);
                int step;
                if (Int32.TryParse(parts[0], out step))
                {
                    if (step == 3)
                    {
                        hasInspiration = true;
                        break;
                    }
                }
            }

            if (!hasInspiration)
            {
                TypingEffect("There are no inspirations to ponder.");
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
                    if (step == 3)
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
                        if (step == 3 && selection == i + 1)
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

        // prompts user to choose the type from _typeList and sets it as _type.
        public void Type()
        // prompts user to choose the type from _typeList and sets it as _type.
        {
            TypingEffect("What type of Inspiration is it?:");
            for (int i = 0; i < _typeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_typeList[i]}");
            }
            Console.WriteLine();
            BlinkIndicator();

            string input = Console.ReadLine();
            int selection;
            if (Int32.TryParse(input, out selection))
            {
                // Check if selection is within range
                if (selection > 0 && selection <= _typeList.Count)
                {
                    _type = _typeList[selection - 1];
                    TypingEffect($"Selected type: {_type}");
                    
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

        // allows the user to copy and paste a scripture text and reference
        public void Script()
        {
            TypingEffect("Copy and paste the text of a scripture which supports this inspiration:");
            Console.WriteLine();
            BlinkIndicator();
            string text = Console.ReadLine();

            TypingEffect("Enter the scripture reference:");
            Console.WriteLine();
            BlinkIndicator();
            string reference = Console.ReadLine();

            _script = $"{text} ({reference})";
            TypingEffect($"Scripture linked: {_script}");
            
        }

        // allows the user to copy and paste a word from church authority text and reference
        public void Word()
        {
            TypingEffect("Copy and paste a quote or text from a Prophet, Apostle or other church authority:");
            Console.WriteLine();
            BlinkIndicator();
            string text = Console.ReadLine();

            TypingEffect("Enter the reference of the quote or text:");
            Console.WriteLine();
            BlinkIndicator();
            string reference = Console.ReadLine();

            _word = $"{text} ({reference})";
            TypingEffect($"Words linked: {_word}");
            
        }

        // selects an inspiration for pondering and allows the user to add type, scripture, and words, then saves it to _inspireList
        public void PonderInspiration()
        {
            InspireSelect();

            if (_select == "") // check if no inspiration has been selected
            {
                return;
            }
            else
            {
                Inspire.DisplayInspiration();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Type();
                Script();
                Word();
                StepUpgrade();
                Inspire.SaveInspiration();
                Inspire.AddLuminosity();
                Inspire.SaveInspireList(); 
            }
            
        }

        // displays the menu and allows the user to select options
        protected override void Menu()
        {

            while (true)
            {
                // Display luminosity score
                Inspire.DisplayLuminosity();

                Console.WriteLine();
                TypingEffect("Select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Ponder about an inspiration");
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
                            Console.Clear();
                            PonderInspiration();
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
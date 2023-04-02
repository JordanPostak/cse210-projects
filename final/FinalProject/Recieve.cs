using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    class Recieve : Program
    {
        // The AddInspire method prompts the user for inspiration text and name, and also allows the user to select associated feelings from a list. It then creates a new inspiration object and adds it to the _inspireList. Finally, it sets the _select variable to the newly added inspiration and calls the AddLuminosity and SaveInspireList methods.
        protected override void AddInspire()
        {
            // Prompts user for inspiration text and sets it to “_inspire”.
            TypingEffect("Enter the inspiration text: ");
            Console.WriteLine();
            BlinkIndicator();
            _inspire = Console.ReadLine();

            // Prompts user or inspiration name and sets it to “_name”.
            TypingEffect("Enter the inspiration name: ");
            Console.WriteLine();
            BlinkIndicator();
            _name = Console.ReadLine();

            // Prompts user to select associated feelings from _feellist.
            _feel = Feelings.GetFeel(_feelList);

            // Sets “_step” as 3
            _step = 3;

            // Sets “_script” as “Undefined“
            _script = "Undefined";

            // Sets “_word” as “Undefined“
            _word = "Undefined";

            // Sets “_link” as “Undefined“
            _link = "Undefined";

            // Sets “act” as “Undefined“
            _act = "Undefined";

            // Sets “_review” as “Undefined“
            _review = "Undefined";

            // Creates new inspiration in this as: _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review. All separated by “///”.
            string newInspirationString = $"{_step}///{_inspire}///{_name}///{_feel}///{_type}///{_script}///{_word}///{_plan}///{_link}///{_act}///{_review}";

            // Appends to _inspireList.
            if (!_inspireList.Contains(newInspirationString))
            {
                _inspireList.Add(newInspirationString);
                TypingEffect($"Added '{_inspire}' to the inspiration list.");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine($"'{_inspire}' is already in the inspiration list.");
                Thread.Sleep(2000);
            }

            // Sets as _select.
            _select = newInspirationString;

            // Calls AddLuminosity()
            Inspire.AddLuminosity();
            Inspire.SaveInspireList();
        }

        // The Menu method displays the current luminosity score and provides the user with a menu to either add a new inspiration or return to the main menu. It continuously prompts the user for input until a valid selection is made. When the user selects the "Add an inspiration" option, the AddInspire method is called.
        protected override void Menu()
        {
        
            // Display luminosity score
            Inspire.DisplayLuminosity();

            while (true)
            {
                Console.WriteLine();
                TypingEffect("Select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Add an inspirations");
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
                            AddInspire();
                            break;
                        case 2:
                            Console.Clear();
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
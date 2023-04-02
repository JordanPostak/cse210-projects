using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    class Plan : Program
    {
        static private string _children = "";
        static private string _selectLink = "";
        static private int _stepLink = 0;
        static private string _inspireLink = "";
        static private string _nameLink = "";
        static private string _feelLink = "";
        static private string _typeLink = "";
        static private string _scriptLink = "";
        static private string _wordLink = "";
        static private string _planLink = "";
        static private string _linkLink = "";
        static private string _actLink = "";
        static private string _reviewLink = "";
        static private string _recordLink = "";
        static private int _indexLink = -1;

        // This method prompts the user to select from a list of inspirations generated by _inspireList (if _step is equal to 4 and the _type is not pearl). It checks if there are any inspirations with step 4 and non-"pearl" type, then displays them in the console for the user to select. Once the user selects an inspiration, it sets the selection as _select and calls InspireSeperate. If there are no inspirations, it displays a message saying so. If the user enters an invalid input, it prompts them to try again.
        protected override void InspireSelect()
        {
            Console.Clear();
            bool hasInspiration = false;

            // Check if there are any inspirations with step 4 and non-"pearl" type
            foreach (string inspire in _inspireList)
            {
                string[] parts = inspire.Split(new string[] { "///" }, StringSplitOptions.None);
                int step;
                string type;
                if (Int32.TryParse(parts[0], out step))
                {
                    type = parts[4];
                    if (step == 4 && type != "Pearl")
                    {
                        hasInspiration = true;
                        break;
                    }
                }
            }

            if (!hasInspiration)
            {
                TypingEffect("There are no inspirations to plan.");
                Thread.Sleep(2000);
                return;
            }

            TypingEffect("\nSelect an inspiration to plan out:");
            Console.WriteLine();
            for (int i = 0; i < _inspireList.Count; i++)
            {
                string[] parts = _inspireList[i].Split(new string[] { "///" }, StringSplitOptions.None);
                int step;
                string type;
                if (Int32.TryParse(parts[0], out step))
                {
                    type = parts[4];
                    if (step == 4 && type != "Pearl")
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
                        if (step == 4 && selection == i + 1)
                        {
                            _index = i;
                            _select = _inspireList[_index];
                            Inspire.InspireSeperate();
                            isValidSelection = true;
                            TypingEffect($"Selected inspiration: {_name}");
                            Thread.Sleep(2000);
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

        // This method prompts the user to enter an inspiration text, an inspiration name, and to select associated feelings from _feellist. It sets the values of _inspireLink, _nameLink, _feelLink, _stepLink, _typeLink, _scriptLink, _wordLink, _planLink, _linkLink, _actLink, and _reviewLink accordingly. It then creates a new inspiration string, adds it to _inspireList if it doesn't already exist, and sets it as _selectLink. If _nameLink is not empty, it adds it to _children. Finally, it calls AddLuminosity.
        protected override void AddInspire()
        {
            // Prompts user for inspiration text and sets it to “_inspire”.
            TypingEffect("Enter the inspiration text: ");
            Console.WriteLine();
            BlinkIndicator();
            _inspireLink = Console.ReadLine();

            // Prompts user or inspiration name and sets it to “_name”.
            TypingEffect("Enter the inspiration name: ");
            Console.WriteLine();
            BlinkIndicator();
            _nameLink = Console.ReadLine();

            // Prompts user to select associated feelings from _feellist.
            _feelLink = Feelings.GetFeel(_feelList);

            // Sets “_step” as 3
            _stepLink = 3;

            // Sets “_type” as “Undefined“
            _typeLink = "Undefined";

            // Sets “_script” as “Undefined“
            _scriptLink = "Undefined";

            // Sets “_word” as “Undefined“
            _wordLink = "Undefined";

            // Sets “_plan” as “Undefined“
            _planLink = "Undefined";

            // Sets “_link” as “Undefined“
            _linkLink = $"Parent:{_name}";

            // Sets “act” as “Undefined“
            _actLink = "Undefined";

            // Sets “_review” as “Undefined“
            _reviewLink = "Undefined";

            // Creates new inspiration in this as: _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review. All separated by “///”.
            string newInspirationString = $"{_stepLink}///{_inspireLink}///{_nameLink}///{_feelLink}///{_typeLink}///{_scriptLink}///{_wordLink}///{_planLink}///{_linkLink}///{_actLink}///{_reviewLink}".Replace("//////", "///");

            // Appends to _inspireList.
            if (!_inspireList.Contains(newInspirationString))
            {
                _inspireList.Add(newInspirationString);
                TypingEffect($"Added '{_inspireLink}' to the inspiration list.");
                Thread.Sleep(2000);
            }
            else
            {
                TypingEffect($"'{_inspireLink}' is already in the inspiration list.");
            }

            // Sets as _selectLink.
            _selectLink = newInspirationString;


           if (!string.IsNullOrEmpty(_nameLink))
            {
                _children += $"{_nameLink}, ";
            }

            // Calls AddLuminosity()
            Inspire.AddLuminosity();
            Inspire.SaveInspireList();
        }

        // This method prompts the user to plan to accomplish the selected inspiration. If it is a Task, it asks the user to pick a date when it is completed and sets the user input as _plan. If it is a Habit, it asks the user how often they want to do the habit and for how long. The method puts the two inputs together and sets it as _plan. If it is a Mission, it asks the user when the mission is due by. If the mission needs to be broken down further, the method calls AddInspire method and keeps asking the user if another inspiration is needed for the mission. Afterward, the method sets the plan, displays it, upgrades the step, and adds luminosity to the inspiration.
        public void Planit()
        {
            Console.Clear();
            Inspire.DisplayInspiration();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            // Prompts the user to plan to accomplish the selected inspiration.
            if (_type == "Task")
            {
                // If it is a Task, asks the user to pick a date when it is completed, sets the user input as _plan.
                Console.WriteLine();
                TypingEffect("Enter the date when the task will be completed (MM/DD/YYYY): ");
                Console.WriteLine();
                BlinkIndicator();
                string taskDate = Console.ReadLine();
                _plan = taskDate;
                TypingEffect($"The plan for {_name} is now set:{_plan}");
                Thread.Sleep(2000);
                StepUpgrade();
                Inspire.AddLuminosity();
            }
            else if (_type == "Habit")
            {
                // If it is a Habit, ask user how often saves to frequent.
               Console.WriteLine();
               TypingEffect("How often do you want to do this habit? (e.g. daily, weekly, etc.): ");
                Console.WriteLine();
                BlinkIndicator();
                string frequent = Console.ReadLine();

                // Then askes the user how long, saves to period.
                Console.WriteLine();
                TypingEffect("How long do you want to keep doing this habit? (e.g. 30 days, 6 weeks, etc.): ");
                Console.WriteLine();
                BlinkIndicator();
                string period = Console.ReadLine();

                // Puts frequent and period together and sets as _plan.
                _plan = $"{frequent} for {period}";
                TypingEffect($"The plan for {_name} is now set:{_plan}");
                Thread.Sleep(2000);
                StepUpgrade();
                Inspire.AddLuminosity();
            }
            else if (_type == "Mission")
            {
                // If it is a Mission, asks the user when the mission is due by.
                Console.WriteLine();
                TypingEffect("Enter the due date for the mission (MM/DD/YYYY): ");
                Console.WriteLine();
                BlinkIndicator();
                string date = Console.ReadLine();

                // Saves the date picked by the user to date.
                _plan = date;

                // Asks the user if it needs to be broken down further.
                Console.WriteLine();
                TypingEffect("Do you need to break down the mission into smaller inspirations? (Y/N): ");
                Console.WriteLine();
                BlinkIndicator();
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    // If yes then call add inspire.
                    AddInspire();

                    // After inspiration is added, keep asking the user if another one is needed for inspiration:_name.
                    while (true)
                    {
                        Console.WriteLine();
                        TypingEffect("Do you want to add another inspiration for this mission? (Y/N): ");
                        Console.WriteLine();
                        BlinkIndicator();
                        string addAnother = Console.ReadLine().ToLower();

                        if (addAnother == "y")
                        {
                            AddInspire();
                        }
                        else
                        // If no, then sets "{date},[1/1]" as _plan.
                        {
                            break;
                        }
                    }
                }
                _plan = date;
                Console.WriteLine();
                TypingEffect($"The plan for {_name} is now set:{_plan}");
                Thread.Sleep(2000);
                StepUpgrade();
                Inspire.AddLuminosity();

            }
        }

        // This method clears the console and calls InspireSelect method. If no inspiration has been selected, the method returns. Otherwise, the method calls Planit method and updates the _link string with the _children value. The method then saves the inspiration and the inspire list.
        public void SetPlan()
        {
            Console.Clear();
            InspireSelect();
            if (_select == "") // check if no inspiration has been selected
            {
                return;
            }
            else
            {
                Planit();
                _link = _link.Replace("Undefined", "");
                _link += $"Children:{_children}";
                Inspire.SaveInspiration();
                Inspire.SaveInspireList();
            }
        }

        // This method displays the luminosity score and prompts the user to select an option: 1) Plan out an inspiration or 2) Return to Main Menu. If the user selects 1, the method calls SetPlan method and checks if no inspiration has been selected. If the user selects 2, the method returns. If the user inputs an invalid selection, the method prompts them to try again.
        protected override void Menu()
        {

            while (true)
            {
                // Display luminosity score
                Console.Clear();
                Inspire.DisplayLuminosity();
                TypingEffect("Select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Plan out an inspiration");
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
                            SetPlan();
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
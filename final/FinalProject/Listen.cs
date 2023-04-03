using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    public class Listen : Program
    {
        private int selectIndex = 0;

        // Load the list of positive items from the positivelist.txt file and add them to the _positiveList variable. If the file does not exist, no action is taken. This method is static, meaning it can be called without an instance of the Listen class.
        static public void LoadPositives()
        {
            // Read the content of the positivelist.txt file
            string filePath = "positivelist.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                // Clear the old positive list before adding new items
                _positiveList.Clear();
                foreach (string line in lines)
                {
                    // Add each line to the _positiveList variable
                    _positiveList.Add(line);
                }
            }
        }

        // Display a prompt to the user to enter a positive thing in their life, and wait for user input. Then prompt the user to select an associated feeling from a list, and add the positive item with the selected feeling to the _positiveList variable. Finally, save the updated list to the positivelist.txt file.
        public void ListPositive()
        {
            LoadPositives();
            Console.Clear();
            TypingEffect("Name something positive in your life:");
            Console.WriteLine();
            BlinkIndicator();
            string positiveItem = Console.ReadLine();
            Feelings.LoadFeelings();
            string feeling = Feelings.GetFeel(_feelList);

            // Add the positive item to _positiveList
            _positiveList.Add($"{positiveItem}///{feeling}");

            Inspire.AddLuminosity();

            // Save the positive items
            SavePositives();

            Console.Clear();
            TypingEffect("Positive item added successfully.");
            Thread.Sleep(2000);
        }

        // Write the content of the _positiveList variable to the positivelist.txt file. If the file does not exist, it is created. If the file exists, its content is overwritten with the content of the _positiveList variable.
        public void SavePositives()
        {
            using (StreamWriter sw = new StreamWriter("positivelist.txt", false))
            {
                foreach (string item in _positiveList)
                {
                    sw.WriteLine(item);
                }
            }
        }
       
       // Display a list of positive items from the _positiveList variable and prompt the user to select an item to edit. Then prompt the user to enter new text for the selected item, and select an associated feeling from a list or add a new feeling. Finally, update the selected item in the _positiveList variable with the new text and feeling, and save the updated list to the positivelist.txt file.
        public void EditPositive()
        {
            LoadPositives();
            Console.Clear();
            TypingEffect("\nSelect a positive item to edit:");
            for (int i = 0; i < _positiveList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_positiveList[i]}");
            }

            string input = Console.ReadLine();
            int selection;
            if (Int32.TryParse(input, out selection))
            {
                // Check if selection is within range
                if (selection > 0 && selection <= _positiveList.Count)
                {
                    selectIndex = selection - 1;
                    Console.Clear();
                    TypingEffect($"Editing item: {_positiveList[selectIndex]}");

                    TypingEffect("Enter new text for the item:");
                    string newText = Console.ReadLine();

                    TypingEffect("\nSelect an associated feeling:");
                    for (int i = 0; i < _feelList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {_feelList[i]}");
                    }
                    TypingEffect($"{_feelList.Count + 1}. Add new feeling");

                    input = Console.ReadLine();
                    if (Int32.TryParse(input, out selection))
                    {
                        if (selection > 0 && selection <= _feelList.Count)
                        {
                            // Use existing feeling
                            _positiveList[selectIndex] = $"{newText}///{_feelList[selection - 1]}";
                        }
                        else if (selection == _feelList.Count + 1)
                        {
                            // Add new feeling
                            string newFeeling = Feelings.AddFeel(_feelList);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, no changes made.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, no changes made.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, no changes made.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, no changes made.");
            }

            // Save the positive items
            SavePositives();
        }

        // This method displays the program's main menu using a print statement and obtains user input using the input function. User input is validated for validity, and the corresponding method is called to perform the selected action. The menu is displayed continuously using a while loop until the user chooses to exit.
        protected override void Menu()
        {

            while (true)
            {
                Console.WriteLine();
                Inspire.DisplayLuminosity();
                TypingEffect("Select an option:");
                Console.WriteLine();
                Console.WriteLine("1. List Positive Things in Life");
                Console.WriteLine("2. Edit Positive List");
                Console.WriteLine("3. Delete from Positive List");
                Console.WriteLine("4. Return to Main Menu");
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
                            ListPositive();
                            break;
                        case 2:
                            Console.Clear();
                            EditPositive();
                            break;
                        case 3:
                            Console.Clear();
                            DeletePositive();
                            break;
                        case 4:
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

        // Display a list of positive items from the _positiveList variable and prompt the user to select an item to delete. Then remove the selected item from the _positiveList variable and save the updated list to the positivelist.txt file.
        public void DeletePositive()
        {
            LoadPositives();
            Console.WriteLine("\nSelect a positive item to delete:");

            for (int i = 0; i < _positiveList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_positiveList[i]}");
            }

            string input = Console.ReadLine();
            int selection;
            if (Int32.TryParse(input, out selection))
            {
                // Check if selection is within range
                if (selection > 0 && selection <= _positiveList.Count)
                {
                    // Get the index of the selected item
                    int index = selection - 1;

                    // Remove the item from _positiveList
                    _positiveList.RemoveAt(index);

                    // Decrement _luminosity by 1
                    _luminosity--;

                    Console.WriteLine("Positive item deleted.");
                    Thread.Sleep(2000);
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

            // Save the positive items
            SavePositives();
            Inspire.SaveInspireList();
        }

        public void Run()
        {
            Menu();
        }
    }
}
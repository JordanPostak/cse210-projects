using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    public class Listen : Program
    {
        private int selectIndex = 0;

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
        }

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
        }

        public void Run()
        {
            Menu();
        }
    }
}
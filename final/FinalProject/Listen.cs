using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    public class Listen : Program
    {
        private int selectIndex = 0;

        public void ListPositive()
        {
            Console.Write("Name something positive in your life: ");
            string positiveItem = Console.ReadLine();

            Console.WriteLine("What word most describes the way it makes you feel:");
            for (int i = 0; i < _feelList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_feelList[i]}");
            }
            Console.WriteLine($"{_feelList.Count + 1}. Add new feeling");

            int choice;
            do
            {
                Console.Write("Please select an option: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > _feelList.Count + 1);

            string feeling;
            if (choice == _feelList.Count + 1)
            {
                Console.Write("Enter new feeling: ");
                feeling = Console.ReadLine();
                _feelList.Add(feeling);
                SaveFeelings();
            }
            else
            {
                feeling = _feelList[choice - 1];
            }

            // Add the positive item to _positiveList
            _positiveList.Add($"{positiveItem}///{feeling}");

            // Increment luminosity by 1
            _luminosity++;

            // Save the positive items
            SavePositives();

            Console.WriteLine("Positive item added successfully.");
        }

        public void SavePositives()
        {
            using (StreamWriter sw = new StreamWriter("positivelist.txt"))
            {
                foreach (string item in _positiveList)
                {
                    sw.WriteLine(item);
                }
            }
            Console.WriteLine("Positive items saved to positivelist.txt.");
        }
        public void SaveFeelings()
        {
            using (StreamWriter writer = new StreamWriter("feelings.txt"))
            {
                foreach (string feeling in _feelList)
                {
                    writer.WriteLine(feeling);
                }
            }
        }
        public void EditPositive()
        {
            Console.WriteLine("\nSelect a positive item to edit:");
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
                    Console.WriteLine($"Editing item: {_positiveList[selectIndex]}");

                    Console.WriteLine("Enter new text for the item:");
                    string newText = Console.ReadLine();

                    Console.WriteLine("\nSelect an associated feeling:");
                    for (int i = 0; i < _feelList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {_feelList[i]}");
                    }
                    Console.WriteLine($"{_feelList.Count + 1}. Add new feeling");

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
                            Console.WriteLine("Enter new feeling:");
                            string newFeeling = Console.ReadLine();
                            _feelList.Add(newFeeling);
                            SaveFeelings();
                            _positiveList[selectIndex] = $"{newText}///{newFeeling}";
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

        public void DeletePositive()
        {
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
            {
                // Display luminosity score
                Console.WriteLine($"Your luminosity score is: {_luminosity}");

                while (true)
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. List Positive Things in Life");
                    Console.WriteLine("2. Edit Positive List");
                    Console.WriteLine("3. Delete from Positive List");
                    Console.WriteLine("4. Return to Main Menu");

                    string input = Console.ReadLine();
                    int selection;
                    if (Int32.TryParse(input, out selection))
                    {
                        switch (selection)
                        {
                            case 1:
                                ListPositive();
                                break;
                            case 2:
                                EditPositive();
                                break;
                            case 3:
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
        }
    }
}
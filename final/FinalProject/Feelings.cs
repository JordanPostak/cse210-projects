using System;
using System.Collections.Generic;
using System.IO;
using InspireStone;

    public class Feelings: Program
    { 
        // This method loads the feelings from the "feelings.txt" file into the program by reading all the lines from the file and creating a new List<string> to store them in. If the file is not found, it prints an error message. If any other exception occurs, it prints an error message that includes the exception's message.
        static public void LoadFeelings()
        {
            try
            {
                string[] feelingLines = File.ReadAllLines("feelings.txt");
                _feelList = new List<string>(feelingLines);
                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Feelings file not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading feelings: {e.Message}");
            }
        }

        // This method saves the provided List<string> of feelings to the "feelings.txt" file by writing each feeling as a new line. It uses a StreamWriter object to write to the file.
        static public void SaveFeelings(List<string>feel)
        {
            using (StreamWriter writer = new StreamWriter("feelings.txt"))
            {
                foreach (string feeling in feel)
                {
                    writer.WriteLine(feeling);
                }
            }
        }

        // This method displays a list of feelings to the user and prompts them to choose one by entering a number. If the user selects the option to add a new feeling, it calls the AddFeel method to add the new feeling to the list and save it to the "feelings.txt" file. If the user selects an existing feeling, it returns that feeling as a string.
        static public string GetFeel(List<string> feelList)
        {
            Console.Clear();
            TypingEffect("How does this make you feel?:");
            for (int i = 0; i < feelList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {feelList[i]}");
            }

            Console.WriteLine($"{feelList.Count + 1}. Add new feeling");

            int choice;
            do
            {
                Console.WriteLine();
                TypingEffect("Please select an option:");
                Console.WriteLine();
                BlinkIndicator();
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > feelList.Count + 1);
            string feeling;

            if (choice == feelList.Count + 1)
            {
                feeling = AddFeel(feelList);
                SaveFeelings(feelList);
            }
            else
            {
                feeling = feelList[choice - 1];
            }
            return feeling;
        }

        // This method prompts the user to enter a new feeling, checks if the feeling already exists in the provided List<string>, and adds it to the list if it doesn't already exist. It then prints a success message, saves the updated list to the "feelings.txt" file, and returns the new feeling as a string.
        static public string AddFeel(List<string> feel)
        {
            string newFeeling;
            do
            {
                Program.TypingEffect("Enter a new feeling: ");
                newFeeling = Console.ReadLine();

                if (feel.Contains(newFeeling))
                {
                    Console.WriteLine($"'{newFeeling}' is already in the feeling list.");
                }
                else
                {
                    feel.Add(newFeeling);
                    Console.Clear();
                    Program.TypingEffect($"Added '{newFeeling}' to the feeling list.");
                    Thread.Sleep(2000);
                    Feelings.SaveFeelings(feel);
                    break;
                }
            } while (true);

            return newFeeling;
        }
    }
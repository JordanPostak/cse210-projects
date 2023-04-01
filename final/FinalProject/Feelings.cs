using System;
using System.Collections.Generic;
using System.IO;
using InspireStone;

    public class Feelings: Program
    { 
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

        static public string GetFeel(List<string> feelList)
        {
            Console.Clear();
            TypingEffect("What word best describes the way you feel:");
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
                    Feelings.SaveFeelings(feel);
                    break;
                }
            } while (true);

            return newFeeling;
        }
    }
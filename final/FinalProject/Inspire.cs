using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    public abstract class Inspire: Program
    {

        // This method saves the current list of inspirations in the _inspireList variable to a file named inspirelist.txt. It starts by opening a StreamWriter object to write to the file. Then, it writes the current luminosity value in the first line of the file and each item in _inspireList to a new line in the file.
        static public void SaveInspireList()
        {
            // Open file for writing
            using (StreamWriter file = new StreamWriter("inspirelist.txt"))
            {
                // Write luminosity to the first line of the file
                file.WriteLine(Program._luminosity);

                // Write each item in inspireList to a new line in the file
                foreach (string item in _inspireList)
                {
                    file.WriteLine(item);
                }
            }
        }

        // This method loads the luminosity score and inspirations from inspirelist.txt and sets them to _luminosity and _inspireList, respectively. It checks if inspirelist.txt exists and reads all its lines. Then, it adds the first line to _luminosity and the rest of the lines to _inspireList.
        static public void InspireList()
        
        {
            if (File.Exists("inspirelist.txt"))
            {
                string[] lines = File.ReadAllLines("inspirelist.txt");
                
                // Add the first line to luminosity int
                if (Int32.TryParse(lines[0], out int lum))
                {
                    Program._luminosity = lum;
                }
                
                // Add the rest of the lines to _inspireList
                for (int i = 1; i < lines.Length; i++)
                {
                    Program._inspireList.Add(lines[i]);
                }
            }
        }

        // This method saves the currently selected inspiration to its corresponding index in _inspireList. It first gets the index of the currently selected inspiration in _inspireList and sets it to _index. Then, it concatenates all the parts of the inspiration, separated by "///", into a single string and replaces any "//////" with "///". Finally, it saves the selected inspiration to the index in _inspireList.
        static public void SaveInspiration()
        {
            // gets index of _select in _inspireList and sets it to _index.
            Program._index = Program._inspireList.IndexOf(Program._select);
        
            //Saves _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review separated by "///" to _select,
            Program._select = string.Join("///", Program._step, Program._inspire, Program._name, Program._feel, Program._type, Program._script, Program._word, Program._plan, Program._link, Program._act, Program._review).Replace("//////", "///");
 
            // Save selected inspiration to index of _inspireList
            if (Program._index != -1)
            {
                Program._inspireList[Program._index] = Program._select;
            }
        }

        // This method takes the currently selected inspiration in _select and separates it by "///". It then sets each part to its corresponding variable in the order _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review. If there are not enough parts, it does not set the corresponding variables.
        static public void InspireSeperate()
        {
            if (Program._select != null)
            {
                string[] parts = Program._select.Split(new[] { "///" }, StringSplitOptions.None);
                if (parts.Length >= 1) Program._step = int.Parse(parts[0]);
                if (parts.Length >= 2) Program._inspire = parts[1];
                if (parts.Length >= 3) Program._name = parts[2];
                if (parts.Length >= 4) Program._feel = parts[3];
                if (parts.Length >= 5) Program._type = parts[4];
                if (parts.Length >= 6) Program._script = parts[5];
                if (parts.Length >= 7) Program._word = parts[6];
                if (parts.Length >= 8) Program._plan = parts[7];
                if (parts.Length >= 9) Program._link = parts[8];
                if (parts.Length >= 10) Program._act = parts[9];
                if (parts.Length >= 11) Program._review = parts[10];
            }
        }

        // This method increments the luminosity score in _luminosity by 1 and displays a message to the console. It simply increments _luminosity by 1 and uses the Console.WriteLine() and Thread.Sleep() methods to display a message for two seconds.
        static public void AddLuminosity()
        {
            // Increment luminosity by 1
            Program._luminosity++;
            Console.WriteLine("Your luminosity score increased by 1!");
            Thread.Sleep(2000);
        }

        // This method displays the current luminosity score in _luminosity to the console. It uses the TypingEffect() method to display a message that shows the current luminosity score.
        static public void DisplayLuminosity()
        {
            TypingEffect($"Your luminosity score is {Program._luminosity}");
        }

        // This method displays the currently selected inspiration to the console in a nice, easy-to-read format. It calls InspireSeperate() to separate the currently selected inspiration into its corresponding parts, then displays each part in a specific order, along with a message indicating what each part represents. It also uses the TypingEffect() method to create a typing effect for each message.
        static public void DisplayInspiration()
        {
            Console.Clear();

            // calls InspireSeperate();
            InspireSeperate();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Displays the variables, _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review, in a nice easy to read manner like this:

            // Inspiration Name: (_name)
            Console.WriteLine();
            TypingEffect("Inspiration Name:");
            Console.ForegroundColor = ConsoleColor.Red;
            TypingEffect($"{_name}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();

            // Type of Inspiration: (_type)
            TypingEffect("Type of Inspiration:");
            Console.ForegroundColor = ConsoleColor.Red;
            TypingEffect($"{_type}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();

            // Step: (if _step equals 3 then Ponder, if 4 then Plan, if 5 then Act, if 6 then Review, if 7 then Record)
            string stepString = "";
            switch (_step)
            {
                case 3:
                    stepString = "Ponder";
                    break;
                case 4:
                    stepString = "Plan";
                    break;
                case 5:
                    stepString = "Act";
                    break;
                case 6:
                    stepString = "Review";
                    break;
                case 7:
                    stepString = "Record";
                    break;
            }
            TypingEffect("Step:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TypingEffect($"{stepString}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();

            // Inspiration Text: (_inspire)
            TypingEffect("Inspiration Text:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TypingEffect($"{_inspire}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();

            // Associated Feeling: (_feel)
            TypingEffect("Associated Feeling:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TypingEffect($"{_feel}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();

            // (Only show if _script is not Undefined) Scriptural Support: (_script)
            if (_script != "Undefined")
            {
                TypingEffect("Scriptural Support:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypingEffect($"{_script}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
            }

            // (Only show if _word is not Undefined) Prophetic Support: (_word)
            if (_word != "Undefined")
            {
                TypingEffect("Prophetic Support:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypingEffect($"{_word}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
            }

            // (Only show if _plan is not Undefined) Plan of Action: (_plan)
            if (_plan != "Undefined")
            {
                TypingEffect("Plan of Action:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                TypingEffect($"{_plan}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
            }

            // (Only show if _link is not Undefined) Child of: (_link)
            if (_link != "Undefined")
            {
                TypingEffect("Related Inspirations:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                TypingEffect($"{_link}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
            }

            // (Only show if _act is not Undefined) Action: (_act)
            if (_act != "Undefined")
            {
                TypingEffect("Action:");
                Console.ForegroundColor = ConsoleColor.Blue;
                TypingEffect($"{_act}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
            }

            // (Only show if _review is not Undefined) Review: (_review)
            if (_review != "Undefined")
            {
                TypingEffect("Review:");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                TypingEffect($"{_review}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
            }
        }
    }
}

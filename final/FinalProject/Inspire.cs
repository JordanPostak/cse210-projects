using System;
using System.Collections.Generic;
using System.IO;

namespace InspireStone
{
    public class Inspire: Program
    {
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

        static public void InspireList()
        // Load luminosity score and inspirations from inspirelist.txt and sets them to luminosity and _inspireList.
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

        static public void SaveInspiration()
        {
            // gets index of _select in _inspireList and sets it to _index.
            Program._index = Program._inspireList.IndexOf(Program._select);
        
            //Saves _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review separated by "///" to _select,
            Program._select = $"{Program._step}///{Program._inspire}///{Program._name}///{Program._feel}///{Program._type}///{Program._script}///{Program._word}///{Program._plan}///{Program._link}///{Program._act}///{Program._review}";
 
            // Save selected inspiration to index of _inspireList
            if (Program._index != -1)
            {
                Program._inspireList[Program._index] = Program._select;
            }
        }

        static public void InspireSeperate()
        // InspireSeperate(): takes _select and separates it by the “///” and separates them into the different parts variables; _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review.
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

        static public void AddLuminosity()
        {
            // Increment luminosity by 1
            Program._luminosity++;
            Console.WriteLine("Your luminosity score increased by 1!");
        }

        static public void DisplayLuminosity()
        {
            TypingEffect($"Your luminosity score is {Program._luminosity}");
        }

        static public void DisplayInspiration()
        {
            // calls InspireSeperate();
            InspireSeperate();

            // clear console
            Console.Clear();

            //Displays the variables, _step, _inspire, _name, _feel, _type, _script, _word, _plan, _link, _act, _review, in a nice easy to read manner like this:

            // Inspiration Name: (_name)
            Console.WriteLine("Inspiration Name:");
            Console.WriteLine($"{_name}");

            // Type of Inspiration: (_type)
            Console.WriteLine("Type of Inspiration:");
            Console.WriteLine($"{_type}");

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
            Console.WriteLine("Step:");
            Console.WriteLine($"{stepString}");

            // Inspiration Text: (_inspire)
            Console.WriteLine("Inspiration Text:");
            Console.WriteLine($"{_inspire}");

            // Associated Feeling: (_feel)
            Console.WriteLine("Associated Feeling:");
            Console.WriteLine($"{_feel}");

            // (Only show if _script is not Undefined) Scriptural Support: (_script)
            if (_script != "Undefined")
            {
                Console.WriteLine("Scriptural Support:");
                Console.WriteLine($"{_script}");
            }

            // (Only show if _word is not Undefined) Prophetic Support: (_word)
            if (_word != "Undefined")
            {
                Console.WriteLine("Prophetic Support:");
                Console.WriteLine($"{_word}");
            }

            // (Only show if _plan is not Undefined) Plan of Action: (_plan)
            if (_plan != "Undefined")
            {
                Console.WriteLine("Plan of Action:");
                Console.WriteLine($"{_plan}");
            }

            // (Only show if _link is not Undefined) Child of: (_link)
            if (_link != "Undefined")
            {
                Console.WriteLine("Child of:");
                Console.WriteLine($"{_link}");
            }

            // (Only show if _act is not Undefined) Action: (_act)
            if (_act != "Undefined")
            {
                Console.WriteLine("Action:");
                Console.WriteLine($"{_act}");
            }

            // (Only show if _review is not Undefined) Review: (_review)
            if (_review != "Undefined")
            {
                Console.WriteLine("Review:");
                Console.WriteLine($"{_review}");
            }
        }
    }
}

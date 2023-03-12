//Program.cs:

//This program goes above and beyond by the creative way the user is able to level up and receive new ranks in addition to the score. The LevelUp() method increases the _finishedgoals counter and updates the _rank variable as it is called in the RecordEvent() method.

using System;

namespace EternalQuest
{
    public class Program
    {
        // Static variables to keep track of progress
        protected static int _finishedgoals { get; set; }// number of finished goals
        protected static string _rank { get; set; }// current rank based on finished goals
        protected static int _score { get; set; }// total score earned
        
        // List to hold goals created by user
        public static  List<Program> _goals = new List<Program>();
        
        // Properties of each goal
        protected string _goaltype { get; set; } // type of goal (Simple, Eternal, Checklist)
        protected string _completed { get; set; } // whether goal is completed or not
        protected string _name { get; set; } // name of the goal
        protected string _description { get; set; } // description of the goal
        protected int _points { get; set; } // point value of the goal
        protected string _count { get; set; } // current count of progress for the goal
        protected int _bonus { get; set; } // bonus points earned for completing the goal

        // Method to create new goal
        static void CreateGoal()
        {
            while (true)
            {
                Console.WriteLine("What type of goal is it?");
                Console.WriteLine("1 - Simple goal");
                Console.WriteLine("2 - Eternal goal");
                Console.WriteLine("3 - Checklist goal");

                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        // Create a new instance of SimpleGoal class and call its Run() method.
                        SimpleGoal simpleGoal = new SimpleGoal();
                        simpleGoal.Run();
                        break;
                    case "2":
                        // Create a new instance of EternalGoal class and call its Run() method.
                        EternalGoal eternalGoal = new EternalGoal();
                        eternalGoal.Run();
                        break;
                    case "3":
                        // Create a new instance of ChecklistGoal class and call its Run() method.
                        ChecklistGoal checklistGoal = new ChecklistGoal();
                        checklistGoal.Run();
                        break;
                    default:
                        // Display an error message for invalid input.
                        Console.WriteLine("Invalid input");
                        break;
                }
                // Exit the loop after a goal is created.
                return;
            }
        }    
        static void RecordEvent()
        {
            // List all the goals that can be recorded
            Console.WriteLine("Goals available to record:");
            for (int i = 0; i < Program._goals.Count; i++)
            {
                Program goal = Program._goals[i];

                // check if the goal is a simple goal and not yet completed
                if (goal._goaltype == "SimpleGoal" && goal._completed == "[]")
                {
                    SimpleGoal simpleGoal = (SimpleGoal)goal;
                    Console.WriteLine($"{i + 1}. SimpleGoal - complete?:{simpleGoal._completed} - {simpleGoal._name} - {simpleGoal._description} points:{simpleGoal._points}");
                }
                // check if the goal is an eternal goal
                else if (goal._goaltype == "EternalGoal")
                {
                    EternalGoal eternalGoal = (EternalGoal)goal;
                    Console.WriteLine($"{i + 1}. EternalGoal - {eternalGoal._name} - {eternalGoal._description} points:{eternalGoal._points}");
                }
                // check if the goal is a checklist goal and not yet completed
                else if (goal._goaltype == "ChecklistGoal" && goal._completed == "[]")
                {
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                    Console.WriteLine($"{i + 1}. ChecklistGoal - complete?:{checklistGoal._completed} - {checklistGoal._count} - {checklistGoal._name} - {checklistGoal._description} points:{checklistGoal._points} - bonus points:{checklistGoal._bonus}");
                }
            }

            // Ask the user which goal they want to record
            Console.WriteLine("Please choose a goal to record:");
            int choice;
            // get user input for the selected goal
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > Program._goals.Count)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            // get the selected goal from the list
            Program selectedGoal = Program._goals[choice - 1];

            // Update the selected goal based on its type

            // if the selected goal is a simple goal
            if (selectedGoal._goaltype == "SimpleGoal")
            {
                SimpleGoal simpleGoal = (SimpleGoal)selectedGoal;
                simpleGoal._completed = "[X]";
                Program._score += simpleGoal._points;
            }
            // if the selected goal is an eternal goal
            else if (selectedGoal._goaltype == "EternalGoal")
            {
                EternalGoal eternalGoal = (EternalGoal)selectedGoal;
                Program._score += eternalGoal._points;
            }
            // if the selected goal is a checklist goal
            else if (selectedGoal._goaltype == "ChecklistGoal")
            {
                // split the count string to get completed and total values
                ChecklistGoal checklistGoal = (ChecklistGoal)selectedGoal;
                string[] parts = checklistGoal._count.Trim('[', ']').Split('/');
                int completed = int.Parse(parts[0]) + 1;
                int total = int.Parse(parts[1]);

                // if all the items on the checklist are completed
                if (completed == total)
                {
                    // add points and bonus points to the score and mark the goal as completed
                    Program._score += checklistGoal._points + checklistGoal._bonus;
                    checklistGoal._completed = "[X]";
                    checklistGoal._count = $"[{completed}/{total}]";
                }
                else
                {
                    // add points to the score and update the count
                    Program._score += checklistGoal._points;
                    checklistGoal._count = $"[{completed}/{total}]";
                }
            }
            // Call LevelUp method
            Program.LevelUp();
        }

        static void ShowGoals()
        {
            // Display the header for the list of goals
            Console.WriteLine("Goals:");

            // Loop through each goal in the list
            foreach (Program goal in _goals)
            {
                // Display a bullet point for each goal
                Console.Write("- ");

                // Check the type of the current goal
                if (goal._goaltype == "SimpleGoal")
                {
                    // Cast the goal to a SimpleGoal object
                    SimpleGoal simpleGoal = (SimpleGoal)goal;

                    // Display the details of the SimpleGoal
                    Console.WriteLine("{0} - complete?:{1} - {2} - {3} - points:{4}", simpleGoal._goaltype, simpleGoal._completed, simpleGoal._name, simpleGoal._description, simpleGoal._points);
                }
                else if (goal._goaltype == "EternalGoal")
                {
                    // Cast the goal to an EternalGoal object
                    EternalGoal eternalGoal = (EternalGoal)goal;

                    // Display the details of the EternalGoal
                    Console.WriteLine("{0} - {1} - {2} - points:{3}", eternalGoal._goaltype, eternalGoal._name, eternalGoal._description, eternalGoal._points);
                }
                else if (goal._goaltype == "ChecklistGoal")
                {
                    // Cast the goal to a ChecklistGoal object
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;

                    // Display the details of the ChecklistGoal
                    Console.WriteLine("{0} - complete?:{1} - count:{2} - {3} - {4} - points:{5} - bonus points:{6}", checklistGoal._goaltype, checklistGoal._completed, checklistGoal._count, checklistGoal._name, checklistGoal._description, checklistGoal._points, checklistGoal._bonus);
                }
            }
        }

        // This function saves the goals to a file with the given filename entered by the user.
        static void SaveGoals()
        {
            try
            {
                Console.WriteLine("Enter filename to save goals:");
                string filename = Console.ReadLine();

                // Using statement ensures that the StreamWriter object is properly disposed after use
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("{0},{1},{2}", Program._score, Program._finishedgoals, Program._rank);
                    
                    // Write each goal to the file
                    foreach (Program goal in _goals)
                    {
                        if (goal._goaltype == "SimpleGoal")
                        {
                            SimpleGoal simpleGoal = (SimpleGoal)goal;
                            writer.WriteLine("{0},{1},{2},{3},{4}", simpleGoal._goaltype, simpleGoal._completed, simpleGoal._name, simpleGoal._description, simpleGoal._points);
                        }
                        else if (goal._goaltype == "EternalGoal")
                        {
                            EternalGoal eternalGoal = (EternalGoal)goal;
                            writer.WriteLine("{0},{1},{2},{3}", eternalGoal._goaltype, eternalGoal._name, eternalGoal._description, eternalGoal._points);
                        }
                        else if (goal._goaltype == "ChecklistGoal")
                        {
                            ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}", checklistGoal._goaltype, checklistGoal._completed, checklistGoal._count, checklistGoal._name, checklistGoal._description, checklistGoal._points, checklistGoal._bonus);
                        }
                    }
                }

                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving goals: " + ex.Message);
            }
        }

        // This function increases the "_finishedgoals" variable by 1 and updates the "_rank" variable
         static void LevelUp()
        {
            _finishedgoals++;
            if (_finishedgoals >= 40)
            {
                _rank = "Divine";
            }
            else if (_finishedgoals >= 39)
            {
                _rank = "Ascendant";
            }
            else if (_finishedgoals >= 36)
            {
                _rank = "Celestial";
            }
            else if (_finishedgoals >= 33)
            {
                _rank = "Hierophant";
            }
            else if (_finishedgoals >= 30)
            {
                _rank = "Oracle";
            }
            else if (_finishedgoals >= 27)
            {
                _rank = "Prophet";
            }
            else if (_finishedgoals >= 24)
            {
                _rank = "Sage";
            }
            else if (_finishedgoals >= 21)
            {
                _rank = "Mystic";
            }
            else if (_finishedgoals >= 18)
            {
                _rank = "Archmage";
            }
            else if (_finishedgoals >= 15)
            {
                _rank = "Magus";
            }
            else if (_finishedgoals >= 12)
            {
                _rank = "Sorcerer";
            }
            else if (_finishedgoals >= 9)
            {
                _rank = "Journeyman";
            }
            else if (_finishedgoals >= 6)
            {
                _rank = "Acolyte";
            }
            else if (_finishedgoals >= 3)
            {
                _rank = "Apprentice";
            }
            else if (_finishedgoals >= 1)
            {
                _rank = "Novice";
            }
        }

        // This function loads goals from a file, parses the data, and sets it in the program.
       static void LoadGoals()
        {
            try
            {
                // Prompt the user to enter the filename to load the goals from
                Console.WriteLine("Enter filename to load goals:");
                string filename = Console.ReadLine();

                // Open the file and read the first line
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line = reader.ReadLine(); // read the first line
                    string[] scoreData = line.Split(','); // split into an array using the comma delimiter
                    int score = int.Parse(scoreData[0]); // parse the score
                    int finishedGoals = int.Parse(scoreData[1]); // parse the finished goals
                    string rank = scoreData[2]; // set the rank as a string

                    Program._score = score; // set the score in the program
                    Program._finishedgoals = finishedGoals; // set the finished goals in the program
                    Program._rank = rank; // set the rank in the program

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        // Check if the goal is a SimpleGoal
                        if (fields.Length == 5)
                        {
                            // SimpleGoal
                            string _goaltype = fields[0];
                            string _completed = fields[1];
                            string _name = fields[2];
                            string _description = fields[3];
                            int _points = int.Parse(fields[4]);

                            // Create a new SimpleGoal and set its fields
                            SimpleGoal goal = new SimpleGoal();
                            goal._goaltype = _goaltype;
                            goal._completed = _completed;
                            goal._name = _name;
                            goal._description = _description;
                            goal._points = _points;

                            // Add the goal to the program's list of goals
                            Program._goals.Add(goal);
                        }
                        // Check if the goal is an EternalGoal
                        else if (fields.Length == 4)
                        {
                            // EternalGoal
                            string _goaltype = fields[0];
                            string _name = fields[1];
                            string _description = fields[2];
                            int _points = int.Parse(fields[3]);

                            // Create a new EternalGoal and set its fields
                            EternalGoal goal = new EternalGoal();
                            goal._goaltype = _goaltype;
                            goal._name = _name;
                            goal._description = _description;
                            goal._points = _points;

                            // Add the goal to the program's list of goals
                            Program._goals.Add(goal);
                        }
                        // Check if the goal is a ChecklistGoal
                        else if (fields.Length == 7)
                        {
                            // ChecklistGoal
                            string _goaltype = fields[0];
                            string _completed = fields[1];
                            string _count = fields[2];
                            string _name = fields[3];
                            string _description = fields[4];
                            int _points = int.Parse(fields[5]);
                            int _bonus = int.Parse(fields[6]);

                            // Create a new ChecklistGoal and set its fields
                            ChecklistGoal goal = new ChecklistGoal();
                            goal._goaltype = _goaltype;
                            goal._completed = _completed;
                            goal._count = _count;
                            goal._name = _name;
                            goal._description = _description;
                            goal._points = _points;
                            goal._bonus = _bonus;

                            // Add the goal to the program's list of goals
                            Program._goals.Add(goal);
                        }
                        else
                        {
                            // If the goal is not in a valid format, print an error message
                            Console.WriteLine("Invalid format in goal file.");
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading goals: " + ex.Message);
            }
        }
        public void GoalStart()
        {
            // Instantiate a new instance of the Program class.
            Program program = new Program();

            // Prompt the user to enter the name of their goal and read the input.
            Console.WriteLine("What is the name of your Goal?");
            _name = Console.ReadLine();

            // Prompt the user to enter a short description of their goal and read the input.        
            Console.WriteLine("What is a short description of it?");
            _description = Console.ReadLine();

            // Prompt the user to enter the amount of points associated with their goal and read the input.
            Console.WriteLine("What are the amount of points associated with this goal?");
            int points;

            // Parse the input and store the result in the '_points' field.
            if (!int.TryParse(Console.ReadLine(), out points))
            {
                Console.WriteLine("Invalid point value. Please enter a valid number.");
                return;
            }
            _points = points;
        }

        

        public virtual void AddToGoalsList()
        {
            // Add the current goal object to the '_goals' list.
            _goals.Add(this);
        }
        static void Main(string[] args)
        {
            // Instantiate a new instance of the Program class.
            Program program = new Program();
            
            // Loop indefinitely until the user chooses to exit.
            while (true)
            {
                // Print out the user's progress and available actions.
                Console.WriteLine($"Finished goals:{_finishedgoals}");
                Console.WriteLine($"Rank:{_rank}");
                Console.WriteLine($"Your Score is {_score}");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1 - Create new goal");
                Console.WriteLine("2 - Record event");
                Console.WriteLine("3 - Show all goals");
                Console.WriteLine("4 - Save goals");
                Console.WriteLine("5 - Load goals");
                Console.WriteLine("6 - Exit");

                // Read the user's input.
                string input = Console.ReadLine();
                
                // Perform the appropriate action based on the user's input.
                switch (input)
                {
                    case "1":
                        // Instantiate a new instance of the Program class.
                        Program prog = new Program();
                        // Call the 'CreateGoal' method to prompt the user to create a new goal.
                        CreateGoal();
                        break;
                    case "2":
                        // Call the 'RecordEvent' method to prompt the user to record a new event.
                        RecordEvent();
                        break;
                    case "3":
                        // Call the 'ShowGoals' method to display all goals.
                        ShowGoals();
                        break;
                    case "4":
                        // Call the 'SaveGoals' method to save all goals to a file.
                        SaveGoals();
                        break;
                    case "5":
                        // Call the 'LoadGoals' method to load all goals from a file.
                        LoadGoals();
                        break;
                    case "6":
                        // Exit the program.
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        // Display an error message for invalid input.
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
//ChecklistGoal.cs:

using System;

namespace EternalQuest
{
    public abstract class Goals : Program
    {

        // This function loads goals from a file, parses the data, and sets it in the program.
        static public void LoadGoals()
        {
            _goals = new List<string>();
            try
            {
                // Prompt the user to enter the filename to load the goals from
                Console.WriteLine("Enter filename to load goals from:");
                string filename = Console.ReadLine();

                // Open the file and read the first line
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line = reader.ReadLine(); // read the first line
                    string[] scoreData = line.Split(','); // split into an array using the comma delimiter
                    _score = int.Parse(scoreData[0]); // parse the score
                    _finishedGoals = int.Parse(scoreData[1]); // parse the finished goals
                    _rank = scoreData[2]; // set the rank as a string

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        // Check if the goal is an EternalGoal
                        if (fields.Length == 4)
                        {
                            // EternalGoal
                            _goalType = fields[0];
                            _name = fields[1];
                            _description = fields[2];
                            _points = int.Parse(fields[3]);

                            // Create a string representation of the goal and add it to the list
                            string goalString = $"{_goalType},{_name},{_description},{_points}";
                            _goals.Add(goalString);
                        }
                        // Check if the goal is a SimpleGoal
                        else if (fields.Length == 5)
                        {
                            // SimpleGoal
                            _goalType = fields[0];
                            _completed = fields[1];
                            _name = fields[2];
                            _description = fields[3];
                            _points = int.Parse(fields[4]);

                            // Create a string representation of the goal and add it to the list
                            string goalString = $"{_goalType},{_completed},{_name},{_description},{_points}";
                            _goals.Add(goalString);
                        }
                        // Check if the goal is a ChecklistGoal
                        else if (fields.Length == 8)
                        {
                            // ChecklistGoal
                            _goalType = fields[0];
                            _completed = fields[1];
                            _comp = int.Parse(fields[2]);
                            _total = int.Parse(fields[3]);
                            _name = fields[4];
                            _description = fields[5];
                            _points = int.Parse(fields[6]);
                            _bonus = int.Parse(fields[7]);

                            // Create a string representation of the goal and add it to the list
                            string goalString = $"{_goalType},{_completed},{_comp},{_total},{_name},{_description},{_points},{_bonus}";
                            _goals.Add(goalString);
                        }
                        else
                        {
                            // If the goal is not in a valid format, print an error message
                            Console.WriteLine("Invalid format in goal file.");
                        }
                        if (_goals.Count == 0)
                        {
                            Console.WriteLine("There are no goals. Press 'enter' to return to the main menu.");
                            Console.ReadLine();
                            return;
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading goals: " + ex.Message);
            }
            Console.WriteLine();
            foreach (string goal in _goals)
            {
                Console.WriteLine(goal);
            }
        }

        static public void GoalStart()
        {
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

        static public void ShowGoals()
        {
            Console.Clear();
            // Loop through each goal in the list
            foreach (string goal in _goals)
            {
                // Split the goal string into its individual fields
                string[] fields = goal.Split(",");

                // Handle goals with different numbers of fields
                if (fields.Length == 4)
                {
                    string goalType = fields[0];
                    string goalName = fields[1];
                    string goalDescription = fields[2];
                    string goalPoints = fields[3];

                    // Display a bullet point for each goal
                    Console.WriteLine($"- Goal type:{goalType}, Goal name:{goalName}, Goal text:{goalDescription}, Points:{goalPoints}");
                }
                else if (fields.Length == 5)
                {
                    string goalType = fields[0];
                    string goalComplete = fields[1];
                    string goalName = fields[2];
                    string goalDescription = fields[3];
                    string goalPoints = fields[4];

                    // Display a bullet point for each goal
                    Console.WriteLine($"- Goal type:{goalType}, Goal Completed?:{goalComplete}, Goal name:{goalName}, Goal text:{goalDescription}, Points:{goalPoints}");
                }
                else if (fields.Length == 8)
                {
                    string goalType = fields[0];
                    string goalComplete = fields[1];
                    string goalComp = fields[2];
                    string goalTotal = fields[3];
                    string goalName = fields[4];
                    string goalDescription = fields[5];
                    string goalPoints = fields[6];
                    string goalBonus = fields[7];

                    string goalCount = $"[{goalComp}/{goalTotal}]";

                    // Display a bullet point for each goal
                    Console.WriteLine($"- Goal type:{goalType}, Goal Completed?:{goalComplete}, Goal Count:{goalCount}, Goal name:{goalName}, Goal text:{goalDescription}, Goal points:{goalPoints}, Bonus points:{goalBonus}");
                }
                else
                {
                    Console.WriteLine($"Invalid goal format: {goal}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press 'enter' to return to the main menu");
            Console.ReadLine();
            Console.Clear();
        }

        // This function saves the goals to a file with the given filename entered by the user.
        static public void SaveGoals()
        {
            try
            {
                Console.WriteLine("Enter filename to save goals:");
                string filename = Console.ReadLine();

                // Using statement ensures that the StreamWriter object is properly disposed after use
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("{0},{1},{2}", _score, _finishedGoals, _rank);

                    // Write each goal to the file
                    foreach (string goal in _goals)
                    {
                        string[] goalData = goal.Split(',');
                        string goalType = goalData[0];
                        if (goalType == "SimpleGoal")
                        {
                            writer.WriteLine("{0},{1},{2},{3},{4}", goalType, goalData[1], goalData[2], goalData[3], goalData[4]);
                        }
                        else if (goalType == "EternalGoal")
                        {
                            writer.WriteLine("{0},{1},{2},{3}", goalType, goalData[1], goalData[2], goalData[3]);
                        }
                        else if (goalType == "ChecklistGoal")
                        {
                            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", goalType, goalData[1], goalData[2], goalData[3], goalData[4], goalData[5], goalData[6], goalData[7]);
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
    }
}

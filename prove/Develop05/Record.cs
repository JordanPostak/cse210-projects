//ChecklistGoal.cs:

using System;

namespace EternalQuest
{
    public abstract class Record : Program
    {
        static public void SelectGoalRecord()
        {
            Console.Clear();
            // Check if there are any goals to display
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                Console.WriteLine("Press 'enter' to return to the main menu");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            // List all the goals that can be recorded
            Console.WriteLine("Goals available to record:");
            for (int i = 0; i < _goals.Count; i++)
            {
                string goalType = ""; // type of goal (Simple, Eternal, Checklist)
                string completed = ""; // whether goal is completed or not
                int comp = 0;
                int total = 0;
                string name = ""; // name of the goal
                string description = ""; // description of the goal
                int points = 0; // point value of the goal
                string count = "";// current count of progress for the goal
                int bonus = 0; // bonus points earned for completing the goal
                string[] goal = _goals[i].Split(',');


                if (goal[0] == "SimpleGoal")
                {
                    goalType = goal[0];
                    completed = goal[1];
                    comp = 0;
                    total = 0;
                    name = goal[2];
                    description = goal[3];
                    points = int.Parse(goal[4]);
                    bonus = 0;
                }
                else if (goal[0] == "EternalGoal")
                {
                    goalType = goal[0];
                    completed = "";
                    comp = 0;
                    total = 0;
                    name = goal[1];
                    description = goal[2];
                    points = int.Parse(goal[3]);
                    bonus = 0;
                }
                else if (goal[0] == "ChecklistGoal")
                {
                    goalType = goal[0];
                    completed = goal[1];
                    comp = int.Parse(goal[2]);
                    total = int.Parse(goal[3]);
                    name = goal[4];
                    description = goal[5];
                    points = int.Parse(goal[6]);
                    bonus = int.Parse(goal[7]);
                }
                // check if the goal is a simple goal and not yet completed
                if (goalType == "SimpleGoal" && completed == "[]")
                {
                    Console.WriteLine($"{i + 1}. Goal type:SimpleGoal, Complete?:{completed}, Name:{name}, Text:{description}, Points:{points}");
                }
                // check if the goal is an eternal goal
                else if (goalType == "EternalGoal")
                {
                    Console.WriteLine($"{i + 1}. Goal type:EternalGoal, Name:{name}, Text:{description}, Points:{points}");
                }
                // check if the goal is a checklist goal and not yet completed
                else if (goalType == "ChecklistGoal" && completed == "[]")
                {
                    Console.WriteLine($"{i + 1}. Goal type:ChecklistGoal, Completed?:{completed}, Count:[{comp}/{total}], Name:{name}, Text:{description} Points:{points}, Bonus points:{bonus}");
                }
            }

            // Ask the user which goal they want to record
            int choice;
            bool isValidChoice = false;
            while (!isValidChoice)
            {
                Console.WriteLine("Please choose a goal to record:");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= _goals.Count)
                {
                    isValidChoice = true;
                    _selectedGoal = _goals[choice - 1];
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and {0}.", _goals.Count);
                }
            }
        }

        static public void SplitSelectedGoal()
        {
            // Split the selected goal string into parts separated by commas
            string[] parts = _selectedGoal.Split(',');

            // Check the goal type and save the appropriate variables
            if (parts[0] == "SimpleGoal")
            {
                _goalType = parts[0];
                _completed = parts[1];
                _count = "";
                _name = parts[2];
                _description = parts[3];
                _points = int.Parse(parts[4]);
                _bonus = 0;
            }
            else if (parts[0] == "EternalGoal")
            {
                _goalType = parts[0];
                _completed = "";
                _count = "";
                _name = parts[1];
                _description = parts[2];
                _points = int.Parse(parts[3]);
                _bonus = 0;
            }
            else if (parts[0] == "ChecklistGoal")
            {
                _goalType = parts[0];
                _completed = parts[1];
                _comp = int.Parse(parts[2]);
                _total = int.Parse(parts[3]);
                _name = parts[4];
                _description = parts[5];
                _points = int.Parse(parts[6]);
                _bonus = int.Parse(parts[7]);
                _count = $"[{_comp}/{_total}]";
            }
        }

        static public void RecordEvent()
        {
            // find the selected goal in goals
            int selectedGoalIndex = _goals.FindIndex(goal => goal == _selectedGoal);

            // Update the selected goal based on its type
            // if the selected goal is a simple goal
            if (_goalType == "SimpleGoal")
            {
                _completed = "[X]";
                _score += _points;

                // update the selected goal in goals
                _goals[selectedGoalIndex] = $"SimpleGoal,{_completed},{_name},{_description},{_points}";
            }
            // if the selected goal is an eternal goal
            else if (_goalType == "EternalGoal")
            {
                _score += _points;
            }
            // if the selected goal is a checklist goal
            else if (_goalType == "ChecklistGoal")
            {
                _comp++;

                // if all the items on the checklist are completed
                if (_comp == _total)
                {
                    // add points and bonus points to the score and mark the goal as completed
                    _score += _points + _bonus;
                    _completed = "[X]";

                    // update the selected goal in goals
                    _goals[selectedGoalIndex] = $"ChecklistGoal,{_completed},{_comp},{_total},{_name},{_description},{_points},{_bonus}";
                }
                else
                {
                    // add points to the score
                    _score += _points;

                     // update the selected goal in goals
                    _goals[selectedGoalIndex] = $"ChecklistGoal,{_completed},{_comp},{_total},{_name},{_description},{_points},{_bonus}";
                }
            }
        }
    }
}

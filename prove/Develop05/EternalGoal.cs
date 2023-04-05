//EternalGoal.cs:

using System;

namespace EternalQuest
{
    public class EternalGoal : Program
    {
        // override AddToGoalsList method to add a new EternalGoal to the list of goals
        protected override void AddToGoalsList()
        {
            // set its _goaltype, _name, _description, and _points fields to the current object's values
            _goalType = "EternalGoal";

            string newGoal = $"{_goalType},{_name},{_description},{_points}";

            // add the new goal to the list of goals in the Program class
            _goals.Add(newGoal);
        }

        // Run method to create a new EternalGoal and add it to the list of goals
        public void Run()
        {
            // call the GoalStart method to get user input for the goal's name, description, and point value
            Goals.GoalStart(); 

            // add the new goal to the list of goals
            AddToGoalsList();

            // print out a message indicating the new EternalGoal was created
            Console.WriteLine();
            Console.WriteLine($"New simple goal created: {_name}");
            Console.WriteLine();

            return;
        }
    }
}
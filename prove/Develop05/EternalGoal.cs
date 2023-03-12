//EternalGoal.cs:

using System;

namespace EternalQuest
{
    public class EternalGoal : Program
    {
        // override AddToGoalsList method to add a new EternalGoal to the list of goals
        public override void AddToGoalsList()
        {
            // create a new EternalGoal object
            EternalGoal newGoal = new EternalGoal();

            // set its _goaltype, _name, _description, and _points fields to the current object's values
            newGoal._goaltype = "EternalGoal";
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;

            // add the new goal to the list of goals in the Program class
            Program._goals.Add(newGoal);
        }

        // Run method to create a new EternalGoal and add it to the list of goals
        public void Run()
        {
            // create a new EternalGoal object
            EternalGoal newGoal = new EternalGoal();

            // call the GoalStart method to get user input for the goal's name, description, and point value
            GoalStart(); 

            // add the new goal to the list of goals
            AddToGoalsList();

            // print out the list of goals and a message indicating the new EternalGoal was created
            Console.WriteLine($"{Program._goals}");
            Console.WriteLine($"New eternal goal created: {_name}");
            return;
        }
    }
}
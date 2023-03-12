//SimpleGoal.cs:

using System;

namespace EternalQuest
{
    public class SimpleGoal : Program
    {
        public override void AddToGoalsList()
        {
            // Create a new instance of SimpleGoal
            SimpleGoal newGoal = new SimpleGoal();

             // Set the properties of the new SimpleGoal object
            newGoal._goaltype = "SimpleGoal";
            newGoal._completed = "[]";
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;

            // Add the new SimpleGoal object to the goals list in the base class (Program)
            Program._goals.Add(newGoal);
        }
        public void Run()
        {
            // Create a new instance of SimpleGoal
            SimpleGoal newGoal = new SimpleGoal();

            // Call the GoalStart method to get user input for the goal
            GoalStart(); 

            // Add the new goal to the goals list
            AddToGoalsList();

            // Print out the updated goals list and a message indicating that a new simple goal was created
            Console.WriteLine($"{Program._goals}");
            Console.WriteLine($"New simple goal created: {_name}");

            
            return; 
        }
    }
}
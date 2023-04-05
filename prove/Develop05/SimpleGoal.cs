//SimpleGoal.cs:

using System;

namespace EternalQuest
{
    public class SimpleGoal : Program
    {
        protected override void AddToGoalsList()
        {
             // Set the properties of the new SimpleGoal object
            _goalType = "SimpleGoal";
            _completed = "[]";

            string newGoal = $"{_goalType},{_completed},{_name},{_description},{_points}";

            // Add the new SimpleGoal object to the goals list in the base class (Program)
            _goals.Add(newGoal);
        }
        public void Run()
        {
            // Call the GoalStart method to get user input for the goal
            Goals.GoalStart(); 

            // Add the new goal to the goals list
            AddToGoalsList();

            // Print out a message indicating that a new simple goal was created
            Console.WriteLine();
            Console.WriteLine($"New simple goal created: {_name}");
            Console.WriteLine();
            
            return; 
        }
    }
}
//ChecklistGoal.cs:

using System;

namespace EternalQuest
{
    public class ChecklistGoal : Program
    {
        // Method to add bonus points to the goal
        public void Bonus()
        {
            // create a new instance of ChecklistGoal class
            ChecklistGoal newGoal = new ChecklistGoal();
            Console.WriteLine("How many times should this goal be completed?");

            // read user input for goal count
            _count = Console.ReadLine();

            Console.WriteLine("How many bonus points will be earned when finished?");
            int bonus;
            // read user input for bonus points
            if (!int.TryParse(Console.ReadLine(), out bonus))
            {
                Console.WriteLine("Invalid bonus value. Please enter a valid number.");
                // return if input is invalid
                return;
            }
            // set the bonus points for the goal
            _bonus = bonus;
        }

        // override method from Program class
        public override void AddToGoalsList()
        {
            // create a new instance of ChecklistGoal class
            ChecklistGoal newGoal = new ChecklistGoal();

            newGoal._goaltype = "ChecklistGoal"; // set the goal type
            newGoal._completed = "[]"; // initialize the completed field as an empty array
            newGoal._count = $"[0/{_count}]"; // set the count field with the total and current count of the goal
            newGoal._name = _name; // set the name field of the goal
            newGoal._description = _description; // set the description field of the goal
            newGoal._points = _points; // set the points field of the goal
            newGoal._bonus = _bonus; // set the bonus field of the goal
            Program._goals.Add(newGoal); // add the new goal to the goals list in Program class
        }

        // define a method to run the creation of a checklist goal
        public void Run()
        {
            // create a new instance of ChecklistGoal class
           ChecklistGoal newGoal = new ChecklistGoal();

           // call the GoalStart method from the Program class
           GoalStart(); 

           // call the Bonus method to set bonus points for the goal
           Bonus();

           // call the AddToGoalsList method to add the new goal to the goals list
           AddToGoalsList();

           // display the updated goals list in the console
           Console.WriteLine($"{Program._goals}");

           // display the name of the new goal created
           Console.WriteLine($"New checklist goal created: {_name}");

           // exit the method
           return;
        }
    }
}
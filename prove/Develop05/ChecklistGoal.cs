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
            Console.WriteLine("How many times should this goal be completed?");

            // read user input for goal count
            while (!int.TryParse(Console.ReadLine(), out _total))
            {
                Console.WriteLine("Invalid input, please enter a valid integer.");
            }

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
        protected override void AddToGoalsList()
        {
            _goalType = "ChecklistGoal"; // set the goal type
            _completed = "[]"; // initialize the completed field as an empty array
            _comp = 0;
            _count = $"[{_comp}/{_total}]"; // set the count field with the total and current count of the goal

            string newGoal = $"{_goalType},{_completed},{_comp},{_total},{_name},{_description},{_points},{_bonus}";

            _goals.Add(newGoal); // add the new goal to the goals list in Program class
        }

        // define a method to run the creation of a checklist goal
        public void Run()
        {
           // call the GoalStart method from the Program class
           Goals.GoalStart(); 

           // call the Bonus method to set bonus points for the goal
           Bonus();

           // call the AddToGoalsList method to add the new goal to the goals list
           AddToGoalsList();

           // display the name of the new goal created
            Console.WriteLine();
            Console.WriteLine($"New simple goal created: {_name}");
            Console.WriteLine();

           // exit the method
           return;
        }
    }
}
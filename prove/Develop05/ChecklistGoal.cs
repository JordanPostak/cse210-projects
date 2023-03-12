//ChecklistGoal.cs:

using System;

namespace EternalQuest
{
    public class ChecklistGoal : Program
    {
        public void Bonus()
        {
            ChecklistGoal newGoal = new ChecklistGoal();
            Console.WriteLine("How many times should this goal be completed?");
            _count = Console.ReadLine();

            Console.WriteLine("How many bonus points will be earned when finished?");
            int bonus;
            if (!int.TryParse(Console.ReadLine(), out bonus))
            {
                Console.WriteLine("Invalid bonus value. Please enter a valid number.");
                return;
            }
            _bonus = bonus;
        }
        public override void AddToGoalsList()
        {
            ChecklistGoal newGoal = new ChecklistGoal();
            newGoal._goaltype = "ChecklistGoal";
            newGoal._completed = "[]";
            newGoal._count = $"[0/{_count}]";
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;
            newGoal._bonus = _bonus;
            Program._goals.Add(newGoal);
        }
        public void Run()
        {
           ChecklistGoal newGoal = new ChecklistGoal();
           GoalStart(); 
           Bonus();
           AddToGoalsList();
           Console.WriteLine($"{Program._goals}");
           Console.WriteLine($"New checklist goal created: {_name}");
           return;
        }
    }
}
//ChecklistGoal.cs:

using System;

namespace EternalQuest
{
    class ChecklistGoal : Program
    {
        string count = "";
        public void Bonus()
        {
            Console.WriteLine("How many times should this goal be completed?");
            string _count = Console.ReadLine();

            Console.WriteLine("How bonus points will be earned when finished?");
            int _bonus;
            if (!int.TryParse(Console.ReadLine(), out _bonus))
            {
                Console.WriteLine("Invalid bonus value. Please enter a valid number.");
                return;
            }
        }
        public override void CreateGoal()
        {
            ChecklistGoal newGoal = new ChecklistGoal();
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;
            newGoal._count = $"0/{_count}";
            _goals.Add(newGoal);
        }
        public void Run()
        {
           GoalStart(); 
           Bonus();
           CreateGoal();
           Console.WriteLine($"New checklist goal created: {_name}");
           return;
        }
    }
}
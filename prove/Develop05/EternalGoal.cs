//EternalGoal.cs:

using System;

namespace EternalQuest
{
    class EternalGoal : Program
    {
        public override void CreateGoal()
        {
            EternalGoal newGoal = new EternalGoal();
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;
            _goals.Add(newGoal);
        }
        public void Run()
        {
           GoalStart(); 
           CreateGoal();
           Console.WriteLine($"New eternal goal created: {_name}");
           return;
        }
    }
}
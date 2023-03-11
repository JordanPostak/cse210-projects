//SimpleGoal.cs:

using System;

namespace EternalQuest
{
    class SimpleGoal : Program
    {
        public override void CreateGoal()
        {
            SimpleGoal newGoal = new SimpleGoal();
            newGoal._completed = "[]";
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;
            _goals.Add(newGoal);
        }
        public void Run()
        {
           GoalStart(); 
           CreateGoal();
           Console.WriteLine($"New simple goal created: {_name}");
           return; 
        }
    }
}
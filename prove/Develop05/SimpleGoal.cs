//SimpleGoal.cs:

using System;

namespace EternalQuest
{
    public class SimpleGoal : Program
    {
        public override void AddToGoalsList()
        {
            SimpleGoal newGoal = new SimpleGoal();
            newGoal._goaltype = "SimpleGoal";
            newGoal._completed = "[]";
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;
            Program._goals.Add(newGoal);
        }
        public void Run()
        {
           SimpleGoal newGoal = new SimpleGoal();
           GoalStart(); 
           AddToGoalsList();
           Console.WriteLine($"{Program._goals}");
           Console.WriteLine($"New simple goal created: {_name}");
           return; 
        }
    }
}
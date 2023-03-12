//EternalGoal.cs:

using System;

namespace EternalQuest
{
    public class EternalGoal : Program
    {
        public override void AddToGoalsList()
        {
            EternalGoal newGoal = new EternalGoal();
            newGoal._goaltype = "EternalGoal";
            newGoal._name = _name;
            newGoal._description = _description;
            newGoal._points = _points;
            Program._goals.Add(newGoal);
        }
        public void Run()
        {
           EternalGoal newGoal = new EternalGoal();
           GoalStart(); 
           AddToGoalsList();
           Console.WriteLine($"{Program._goals}");
           Console.WriteLine($"New eternal goal created: {_name}");
           return;
        }
    }
}
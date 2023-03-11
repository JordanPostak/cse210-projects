//EternalGoal.cs:

using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class EternalGoal : Program
    {
        public override void CreateGoal()
        {
            EternalGoal newGoal = new EternalGoal();
            newGoal._goaltype = "EternalGoal";
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
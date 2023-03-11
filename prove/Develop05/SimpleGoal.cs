//SimpleGoal.cs:

using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class SimpleGoal : Program
    {
        public override void CreateGoal()
        {
            SimpleGoal newGoal = new SimpleGoal();
            newGoal._goaltype = "SimpleGoal";
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
           Console.WriteLine(_goals);
           Console.WriteLine($"New simple goal created: {_name}");
           return; 
        }
    }
}
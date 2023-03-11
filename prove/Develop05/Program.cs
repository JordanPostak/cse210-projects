//Program.cs:

using System;
using System.Collections.Generic;

namespace EternalQuest
{
    class Program
    {
        
        protected static List<Program> _goals = new List<Program>();
        protected string _completed { get; set; }
        protected string _name { get; set; }
        protected string _description { get; set; }
        protected int _points { get; set; }
        protected string _count { get; set; }
        protected int _bonus { get; set; }
        protected int _score { get; set; }

        public virtual void CreateGoal()
        {
            while (true)
            {
                Console.WriteLine("What type of goal is it?");
                Console.WriteLine("1 - Simple goal");
                Console.WriteLine("2 - Eternal goal");
                Console.WriteLine("3 - Checklist goal");

                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        SimpleGoal simpleGoal = new SimpleGoal();
                        simpleGoal.Run();
                        break;
                    case "2":
                        EternalGoal eternalGoal = new EternalGoal();
                        eternalGoal.Run();
                        break;
                    case "3":
                        ChecklistGoal checklistGoal = new ChecklistGoal();
                        checklistGoal.Run();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                return;
            }
        }    
        public static void RecordEvent(string goalName)
        {
            Program goal = _goals.Find(g => g._name == goalName);

            if (goal != null)
            {
                goal._completed = "[X]";
                Console.WriteLine("Event recorded successfully!");
            }
            else
            {
                Console.WriteLine("Goal not found.");
            }
        }

        public static void ShowGoals()
        {
            Console.WriteLine("Goals:");
            foreach (Program goal in _goals)
            {
                Console.WriteLine("- {0} ({1} points) - {2}", goal._name, goal._points, goal._description);
            }
        }

    public static void SaveGoals()
        {
            try
            {
                Console.WriteLine("Enter filename to save goals:");
                string filename = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Program goal in _goals)
                    {
                        writer.WriteLine("{0},{1},{2},{3}", goal._name, goal._description, goal._points, goal._completed);
                    }
                }

                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving goals: " + ex.Message);
            }
        }

        public static void LoadGoals()
        {
            try
            {
                Console.WriteLine("Enter filename to load goals:");
                string filename = Console.ReadLine();

                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        string description = fields[1];
                        int points = int.Parse(fields[2]);
                        string completed = fields[3];
                        string count = fields[4];
                        int bonus = int.Parse(fields[5]);

                        Program goal = new Program()
                        {
                            _name = name,
                            _description = description,
                            _points = points,
                            _completed = completed,
                            _count = count,
                            _bonus = bonus
                        };

                        _goals.Add(goal);
                    }
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading goals: " + ex.Message);
            }
        }
        public static void GoalStart()
        {
            Console.WriteLine("What is the name of your Simple Goal?");
            string _name = Console.ReadLine();
    

            Console.WriteLine("What is a short description of it?");
            string _description = Console.ReadLine();

            Console.WriteLine("What is the amount of points associated with this goal?");
            int _points;
            if (!int.TryParse(Console.ReadLine(), out _points))
            {
                Console.WriteLine("Invalid point value. Please enter a valid number.");
                return;
            }
        }
        public static void Main(string[] args)
        {
            Program program = new Program();

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1 - Create new goal");
                Console.WriteLine("2 - Record event");
                Console.WriteLine("3 - Show all goals");
                Console.WriteLine("4 - Save goals");
                Console.WriteLine("5 - Load goals");
                Console.WriteLine("6 - Exit");

                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        Program prog = new Program();
                        program.CreateGoal();
                        break;
                    case "2":
                        Console.WriteLine("Enter goal name:");
                        string goalName = Console.ReadLine();
                        RecordEvent(goalName);
                        break;
                    case "3":
                        ShowGoals();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
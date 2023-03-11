//Program.cs:

using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        protected static int _score { get; set; }
        protected static List<Program> _goals = new List<Program>();
        protected string _goaltype { get; set; }
        protected string _completed { get; set; }
        protected string _name { get; set; }
        protected string _description { get; set; }
        protected int _points { get; set; }
        protected string _count { get; set; }
        protected int _bonus { get; set; }

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
public static void RecordEvent()
{

    // Ask the user which goal they want to record
    Console.WriteLine("Please choose a goal to record:");
    for (int i = 0; i < _goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_goals[i]._name}");
    }
    int choice;
    if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > _goals.Count)
    {
        Console.WriteLine("Invalid input.");
        return;
    }
    Program selectedGoal = _goals[choice - 1];

    // Update the selected goal based on its type
    if (selectedGoal._goaltype is "SimpleGoal")
    {
        selectedGoal._completed = "[X]";
        _score += selectedGoal._points;
    }
    else if (selectedGoal._goaltype is "EternalGoal")
    {
        _score += selectedGoal._points;
    }
    else if (selectedGoal._goaltype is "ChecklistGoal")
    {
        selectedGoal._count += 1;
        string[] parts = selectedGoal._completed.Split('/');
        int completed = int.Parse(parts[0]) + 1;
        int total = int.Parse(parts[1]);
        if (completed == total)
        {
            _score += selectedGoal._points + selectedGoal._bonus;
        }
        else
        {
            _score += selectedGoal._points;
        }
        selectedGoal._count = $"[{completed}/{total}]";
    }
}

        public static void ShowGoals()
        {
            Console.WriteLine("Goals:");
            foreach (Program goal in _goals)
            {
                Console.WriteLine("- {0} ({1} points) - {2}", goal._name, goal._description);
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
                
                Console.WriteLine($"Your Score is {_score}");
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
                        RecordEvent();
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
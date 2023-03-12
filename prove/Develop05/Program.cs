//Program.cs:

using System;

namespace EternalQuest
{
    public class Program
    {
        protected static int _score { get; set; }
        public static  List<Program> _goals = new List<Program>();
        protected string _goaltype { get; set; }
        protected string _completed { get; set; }
        protected string _name { get; set; }
        protected string _description { get; set; }
        protected int _points { get; set; }
        protected string _count { get; set; }
        protected int _bonus { get; set; }

        static void CreateGoal()
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
        static void RecordEvent()
        {
            // List all the goals that can be recorded
            Console.WriteLine("Goals available to record:");
            for (int i = 0; i < Program._goals.Count; i++)
            {
                Program goal = Program._goals[i];
                if (goal._goaltype == "SimpleGoal" && goal._completed == "[]")
                {
                    SimpleGoal simpleGoal = (SimpleGoal)goal;
                    Console.WriteLine($"{i + 1}. SimpleGoal - complete?:{simpleGoal._completed} - {simpleGoal._name} - {simpleGoal._description} points:{simpleGoal._points}");
                }
                else if (goal._goaltype == "EternalGoal")
                {
                    EternalGoal eternalGoal = (EternalGoal)goal;
                    Console.WriteLine($"{i + 1}. EternalGoal - {eternalGoal._name} - {eternalGoal._description} points:{eternalGoal._points}");
                }
                else if (goal._goaltype == "ChecklistGoal" && goal._completed == "[]")
                {
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                    Console.WriteLine($"{i + 1}. ChecklistGoal - complete?:{checklistGoal._completed} - {checklistGoal._count} - {checklistGoal._name} - {checklistGoal._description} points:{checklistGoal._points} - bonus points:{checklistGoal._bonus}");
                }
            }

            // Ask the user which goal they want to record
            Console.WriteLine("Please choose a goal to record:");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > Program._goals.Count)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            Program selectedGoal = Program._goals[choice - 1];

            // Update the selected goal based on its type
            if (selectedGoal._goaltype == "SimpleGoal")
            {
                SimpleGoal simpleGoal = (SimpleGoal)selectedGoal;
                simpleGoal._completed = "[X]";
                Program._score += simpleGoal._points;
            }
            else if (selectedGoal._goaltype == "EternalGoal")
            {
                EternalGoal eternalGoal = (EternalGoal)selectedGoal;
                Program._score += eternalGoal._points;
            }
            else if (selectedGoal._goaltype == "ChecklistGoal")
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)selectedGoal;
                string[] parts = checklistGoal._count.Trim('[', ']').Split('/');
                int completed = int.Parse(parts[0]) + 1;
                int total = int.Parse(parts[1]);
                if (completed == total)
                {
                    Program._score += checklistGoal._points + checklistGoal._bonus;
                    checklistGoal._completed = "[X]";
                    checklistGoal._count = $"[{completed}/{total}]";
                }
                else
                {
                    Program._score += checklistGoal._points;
                    checklistGoal._count = $"[{completed}/{total}]";
                }
            }
        }

        static void ShowGoals()
        {
            Console.WriteLine("Goals:");
            foreach (Program goal in _goals)
            {
                Console.Write("- ");
                if (goal._goaltype == "SimpleGoal")
                {
                    SimpleGoal simpleGoal = (SimpleGoal)goal;
                    Console.WriteLine("{0} - complete?:{1} - {2} - {3} - points:{4}", simpleGoal._goaltype, simpleGoal._completed, simpleGoal._name, simpleGoal._description, simpleGoal._points);
                }
                else if (goal._goaltype == "EternalGoal")
                {
                    EternalGoal eternalGoal = (EternalGoal)goal;
                    Console.WriteLine("{0} - {1} - {2} - points:{3}", eternalGoal._goaltype, eternalGoal._name, eternalGoal._description, eternalGoal._points);
                }
                else if (goal._goaltype == "ChecklistGoal")
                {
                    ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                    Console.WriteLine("{0} - complete?:{1} - count:{2} - {3} - {4} - points:{5} - bonus points:{6}", checklistGoal._goaltype, checklistGoal._completed, checklistGoal._count, checklistGoal._name, checklistGoal._description, checklistGoal._points, checklistGoal._bonus);
                }
            }
        }

        static void SaveGoals()
        {
            try
            {
                Console.WriteLine("Enter filename to save goals:");
                string filename = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(Program._score);
                    foreach (Program goal in _goals)
                    {
                        if (goal._goaltype == "SimpleGoal")
                        {
                            SimpleGoal simpleGoal = (SimpleGoal)goal;
                            writer.WriteLine("{0},{1},{2},{3},{4}", simpleGoal._goaltype, simpleGoal._completed, simpleGoal._name, simpleGoal._description, simpleGoal._points);
                        }
                        else if (goal._goaltype == "EternalGoal")
                        {
                            EternalGoal eternalGoal = (EternalGoal)goal;
                            writer.WriteLine("{0},{1},{2},{3}", eternalGoal._goaltype, eternalGoal._name, eternalGoal._description, eternalGoal._points);
                        }
                        else if (goal._goaltype == "ChecklistGoal")
                        {
                            ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}", checklistGoal._goaltype, checklistGoal._completed, checklistGoal._count, checklistGoal._name, checklistGoal._description, checklistGoal._points, checklistGoal._bonus);
                        }
                    }
                }

                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving goals: " + ex.Message);
            }
        }

       static void LoadGoals()
        {
            try
            {
                Console.WriteLine("Enter filename to load goals:");
                string filename = Console.ReadLine();

                using (StreamReader reader = new StreamReader(filename))
                {
                    string line = reader.ReadLine(); // read the first line as score
                    int score = int.Parse(line); // parse the score
                    Program._score = score; // set the score in the program

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        if (fields.Length == 5)
                        {
                            // SimpleGoal
                            
                            string _goaltype = fields[0];
                            string _completed = fields[1];
                            string _name = fields[2];
                            string _description = fields[3];
                            int _points = int.Parse(fields[4]);

                            SimpleGoal goal = new SimpleGoal();
                            goal._goaltype = _goaltype;
                            goal._completed = _completed;
                            goal._name = _name;
                            goal._description = _description;
                            goal._points = _points;

                            Program._goals.Add(goal);
                        }
                        else if (fields.Length == 4)
                        {
                            // EternalGoal
                            string _goaltype = fields[0];
                            string _name = fields[1];
                            string _description = fields[2];
                            int _points = int.Parse(fields[3]);

                            EternalGoal goal = new EternalGoal();
                            goal._goaltype = _goaltype;
                            goal._name = _name;
                            goal._description = _description;
                            goal._points = _points;

                            Program._goals.Add(goal);
                        }
                        else if (fields.Length == 7)
                        {
                            // ChecklistGoal
                            string _goaltype = fields[0];
                            string _completed = fields[1];
                            string _count = fields[2];
                            string _name = fields[3];
                            string _description = fields[4];
                            int _points = int.Parse(fields[5]);
                            int _bonus = int.Parse(fields[6]);

                            ChecklistGoal goal = new ChecklistGoal();
                            goal._goaltype = _goaltype;
                            goal._completed = _completed;
                            goal._count = _count;
                            goal._name = _name;
                            goal._description = _description;
                            goal._points = _points;
                            goal._bonus = _bonus;

                            Program._goals.Add(goal);
                        }
                        else
                        {
                            Console.WriteLine("Invalid format in goal file.");
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading goals: " + ex.Message);
            }
        }
        public void GoalStart()
        {
            Program program = new Program();
            Console.WriteLine("What is the name of your Goal?");
            _name = Console.ReadLine();
                    
            Console.WriteLine("What is a short description of it?");
            _description = Console.ReadLine();

            Console.WriteLine("What are the amount of points associated with this goal?");
            int points;
            if (!int.TryParse(Console.ReadLine(), out points))
            {
                Console.WriteLine("Invalid point value. Please enter a valid number.");
                return;
            }
            _points = points;
        }

        public virtual void AddToGoalsList()
        {
            _goals.Add(this);
        }
        static void Main(string[] args)
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
                        CreateGoal();
                        break;
                    case "2":
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
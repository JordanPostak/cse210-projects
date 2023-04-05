//Program.cs:

//This program goes above and beyond by the creative way the user is able to level up and receive new ranks in addition to the score. The LevelUp() method increases the _finishedgoals counter and updates the _rank variable as it is called in the RecordEvent() method.

using System;

namespace EternalQuest
{
    public class Program
    {
        // Static variables to keep track of progress
        static protected int _finishedGoals; // number of finished goals
        static protected string _rank = "No rank yet"; // current rank based on finished goals
        static protected int _score;// total score earned
        
        // List to hold goals created by user
        static protected List<string> _goals = new List<string>();
        
        //new goal created
        static protected string _selectedGoal;
        
        // Properties of each goal
        static protected string _goalType; // type of goal (Simple, Eternal, Checklist)
        static protected string _completed; // whether goal is completed or not
        static protected string _name; // name of the goal
        static protected string _description; // description of the goal
        static protected int _points; // point value of the goal
        static protected int _comp = 0;// current completed progress for checklist goals which is used to display in _count
        static protected int _total = 0;// current total progress for checklist goals which is used to display in _count
        static protected string _count = $"[{_comp}/{_total}]";// current total progress for checklist goals which is used to display in _count
        static protected int _bonus; // bonus points earned for completing the goal

        // This function increases the "_finishedgoals" variable by 1 and updates the "_rank" variable
        static protected void LevelUp()
        {
            _finishedGoals++;
            if (_finishedGoals >= 40)
            {
                _rank = "Divine";
            }
            else if (_finishedGoals >= 39)
            {
                _rank = "Ascendant";
            }
            else if (_finishedGoals >= 36)
            {
                _rank = "Celestial";
            }
            else if (_finishedGoals >= 33)
            {
                _rank = "Hierophant";
            }
            else if (_finishedGoals >= 30)
            {
                _rank = "Oracle";
            }
            else if (_finishedGoals >= 27)
            {
                _rank = "Prophet";
            }
            else if (_finishedGoals >= 24)
            {
                _rank = "Sage";
            }
            else if (_finishedGoals >= 21)
            {
                _rank = "Mystic";
            }
            else if (_finishedGoals >= 18)
            {
                _rank = "Archmage";
            }
            else if (_finishedGoals >= 15)
            {
                _rank = "Magus";
            }
            else if (_finishedGoals >= 12)
            {
                _rank = "Sorcerer";
            }
            else if (_finishedGoals >= 9)
            {
                _rank = "Journeyman";
            }
            else if (_finishedGoals >= 6)
            {
                _rank = "Acolyte";
            }
            else if (_finishedGoals >= 3)
            {
                _rank = "Apprentice";
            }
            else if (_finishedGoals >= 1)
            {
                _rank = "Novice";
            }
        }

        protected virtual void AddToGoalsList()
        {
            // Add the current goal to the '_goals' list.
        }

        static void Main(string[] args)
        {
            // Instantiate a new instance of the Program class.
            Program program = new Program();
            
            Console.Clear();
            Console.WriteLine("Welcome!");
            Console.WriteLine();

            // Loop indefinitely until the user chooses to exit.
            while (true)
            {
                // Print out the user's progress and available actions.
                Console.WriteLine($"Goals Recorded:{_finishedGoals}");
                Console.WriteLine();
                Console.WriteLine($"Rank:{_rank}");
                Console.WriteLine();
                Console.WriteLine($"Your Score is {_score}");
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine();
                Console.WriteLine("1 - Create new goal");
                Console.WriteLine("2 - Record event");
                Console.WriteLine("3 - Show all goals");
                Console.WriteLine("4 - Save goals");
                Console.WriteLine("5 - Load goals");
                Console.WriteLine("6 - Exit");
                Console.WriteLine();

                // Read the user's input.
                string input = Console.ReadLine();
                
                // Perform the appropriate action based on the user's input.
                switch (input)
                {
                    case "1":
                        // Call the 'CreateGoal' method to prompt the user to create a new goal.
                        CreateGoalMenu();
                        break;
                    case "2":
                        // Call the 'SelectGoalRecord' and 'RecordEvent' method to prompt the user to record a new event.
                        Record.SelectGoalRecord();
                        if (_goals.Count == 0)
                        {
                            break;
                        }
                        Record.SplitSelectedGoal();
                        Record.RecordEvent();
                        // Call LevelUp method
                        LevelUp();
                        break;
                    case "3":
                        // Call the 'ShowGoals' method to display all goals.
                        Goals.ShowGoals();
                        break;
                    case "4":
                        // Call the 'SaveGoals' method to save all goals to a file.
                        Goals.SaveGoals();
                        break;
                    case "5":
                        // Call the 'LoadGoals' method to load all goals from a file.
                        Goals.LoadGoals();
                        break;
                    case "6":
                        // Exit the program.
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        // Display an error message for invalid input.
                        Console.WriteLine("Invalid input");
                        break;
                }

                // Method to create new goal
                static void CreateGoalMenu()
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("What type of goal is it?");
                        Console.WriteLine();
                        Console.WriteLine("1 - Simple goal");
                        Console.WriteLine("2 - Eternal goal");
                        Console.WriteLine("3 - Checklist goal");
                        Console.WriteLine();

                        string input = Console.ReadLine();
                        
                        switch (input)
                        {
                            case "1":
                                // Create a new instance of SimpleGoal class and call its Run() method.
                                SimpleGoal simpleGoal = new SimpleGoal();
                                simpleGoal.Run();
                                break;
                            case "2":
                                // Create a new instance of EternalGoal class and call its Run() method.
                                EternalGoal eternalGoal = new EternalGoal();
                                eternalGoal.Run();
                                break;
                            case "3":
                                // Create a new instance of ChecklistGoal class and call its Run() method.
                                ChecklistGoal checklistGoal = new ChecklistGoal();
                                checklistGoal.Run();
                                break;
                            default:
                                // Display an error message for invalid input.
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        // Exit the loop after a goal is created.
                        return;
                    }
                }    
            }
        }
    }
}
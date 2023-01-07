using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        String grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 97)
        {
            letter = "A+";
        }
        else if (percent >= 93)
        {
            letter = "A";
        }
        else if (percent >= 90)
        {
            letter = "A-";
        }
        else if (percent >= 97)
        {
            letter = "B+";
        }
        else if (percent >= 83)
        {
            letter = "B";
        }
        else if (percent >= 80)
        {
            letter = "B-";
        }
        else if (percent >= 77)
        {
            letter = "C+";
        }
        else if (percent >= 73)
        {
            letter = "C";
        }
        else if (percent >= 70)
        {
            letter = "C-";
        }
        else if (percent >= 67)
        {
            letter = "D+";
        }
        else if (percent >= 65)
        {
            letter = "D";
        }
        else if (percent >= 60)
        {
            letter = "D-";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >= 97)
        {
            Console.WriteLine("Wow! you are very good at school!");
        }
        else if (percent >= 60)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
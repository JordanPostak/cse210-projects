using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Jordan Postak", "Addition");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Jesse Postak", "Subtraction", "6.2", "10-20");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Ann Postak", "American Heratage", "The Migration of the Pioneers");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
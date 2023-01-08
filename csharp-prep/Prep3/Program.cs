using System;

class Program
{
    static void Main(string[] args)
   {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int number = 0;
        string restart = "y";


        while (restart == "y")
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
                number++;
                Console.WriteLine($"You have guessed {number} times.");

            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
                number++;
                Console.WriteLine($"You have guessed {number} times.");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                number++;
                Console.WriteLine($"You have guessed {number} times.");
                Console.Write("Do you want to continue? ");
                restart = Console.ReadLine();
            }

        }                    
    }
}
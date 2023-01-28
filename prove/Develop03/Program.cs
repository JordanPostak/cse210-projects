//This is my Program.cs file
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the Scripture class
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

        // Create an instance of the Memorizer class
        Memorizer memorizer = new Memorizer(scripture);

        // Start the memorization process
        memorizer.Start();
    }
}






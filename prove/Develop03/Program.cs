//This is my Program.cs file
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an array of scripture objects
        Scripture[] scriptures = new Scripture[] {
            new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding.\nIn all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture("2 Nephi 2:25", "Adam fell that men might be; and men are, that they might have joy."),
            new Scripture("3 Nephi 11:10-11", "Behold, I am Jesus Christ, whom the prophets testified shall come into the world.\nAnd behold, I am the alight and the life of the world; and I have drunk out of that bitter cup which the Father hath given me, and have glorified the Father in taking upon me the sins of the world, in the which I have suffered the will of the Father in all things from the beginning."),
            new Scripture("Moroni 7:45", "And charity suffereth long, and is kind, and envieth not, and is not puffed up, seeketh not her own, is not easily provoked, thinketh no evil, and rejoiceth not in iniquity but rejoiceth in the truth, beareth all things, believeth all things, hopeth all things, endureth all things."),
            new Scripture("Abraham 3:22-23", "Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones;\nAnd God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born.")
        };
        Console.WriteLine();
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("Here is a list of scriptures:");

        // Display the scripture references and prompt the user to select one
        Console.WriteLine();
        for (int i = 0; i < scriptures.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].Reference}");
        }
        Console.WriteLine();
        Console.Write("Select a scripture to memorize: ");
        int selection = int.Parse(Console.ReadLine());
        Scripture selectedScripture = scriptures[selection - 1];

        // Create an instance of the Memorizer class
        Memorizer memorizer = new Memorizer(selectedScripture);

        // Start the memorization process
        memorizer.Start();
    }
}

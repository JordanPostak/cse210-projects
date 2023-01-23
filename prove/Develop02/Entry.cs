class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    //List of predefined prompts
    internal static List<string> prompts = new List<string> { "What did I achieve today?",
        "What did I learn today?",
        "What did I struggle with today?",
        "What did I enjoy most about today?",
        "How did I take care of my physical, emotional and mental well-being today?",
        "Who did I interact with today?",
        "What did I do for fun today?",
        "How did I challenge myself today?",
        "What did I do to contribute to my personal growth today?"};


    // constructor - creates a new instance of the Entry class with the given prompt, response and date values
    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // display entries
    public void Display()
    {
        Console.WriteLine("Prompt: " + this.Prompt);
        Console.WriteLine("Response: " + this.Response);
        Console.WriteLine("Date: " + this.Date);
    }

    // get prompt
    public static string GetPrompt()
    {
        int option = GetPromptOption();
        return prompts[option];
    }

    // get prompt option
    private static int GetPromptOption()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Select prompt:");
        Console.ForegroundColor = ConsoleColor.Blue;

        for (int i = 0; i < prompts.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + prompts[i]);
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        int option;
        Console.WriteLine();
        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > prompts.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter a number between 1 and 9" + prompts.Count);
        }
        return option - 1;
    }
}
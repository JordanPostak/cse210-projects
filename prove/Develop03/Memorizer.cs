//This is my Memorizer.cs file

class Memorizer
{
    private Scripture scripture;
    private string[] words;
    private bool[] hiddenWords;
    private Random rand;

    public Memorizer(Scripture scripture)
    {
        this.scripture = scripture;
        words = scripture.Text.Split(" ");
        hiddenWords = new bool[words.Length];
        rand = new Random();
    }

    public void Start()
    {
        ClearConsole();
        DisplayScripture();

        while (true)
        {
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            HideRandomWords();
            ClearConsole();
            DisplayScripture();

            if (IsScriptureFullyHidden())
                break;
        }
    }

    private void HideRandomWords()
    {
        int count = rand.Next(1, words.Length / 2);
        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(0, words.Length);
            if (!hiddenWords[index])
                hiddenWords[index] = true;
            else
                i--;
        }
    }

    private bool IsScriptureFullyHidden()
    {
        return !hiddenWords.Contains(false);
    }

    private void DisplayScripture()
    {
        Console.WriteLine(scripture.Reference);
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords[i])
                Console.Write("_ ");
            else
                Console.Write(words[i] + " ");
        }
    }

    private void ClearConsole()
    {
        Console.Clear();
    }
}
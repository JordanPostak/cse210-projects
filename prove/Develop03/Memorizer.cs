//This is my Memorizer.cs file

class Memorizer
{
    private Scripture scripture;
    private string[] words;
    private string[] hiddenWords;
    private Random rand;

    public Memorizer(Scripture scripture)
    {
        this.scripture = scripture;
        words = scripture.Text.Split(" ");
        hiddenWords = new string[words.Length];
        rand = new Random();
    }

    public void Start()
    {
        ClearConsole();
        DisplayScripture();

        while (!IsScriptureFullyHidden())
        {
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            HideRandomWords();
            ClearConsole();
            DisplayScripture();
        }
    }

private void HideRandomWords()
{
    int remainingWords = hiddenWords.Count(word => word == null);

    if (remainingWords <= 3)
    {
        for (int i = 0; i < hiddenWords.Length; i++)
        {
            if (hiddenWords[i] == null)
            {
                hiddenWords[i] = new string('_', words[i].Length);
                remainingWords--;
            }
        }
    }
    else
    {
        int count = rand.Next(1, Math.Min(remainingWords, remainingWords / 2));
        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(0, words.Length);
            if (hiddenWords[index] == null)
            {
                hiddenWords[index] = new string('_', words[index].Length);
                remainingWords--;
            }
            else
                i--;
        }
    }
}

    private bool IsScriptureFullyHidden()
    {
        return !hiddenWords.Contains(null);
    }

    private void DisplayScripture()
    {
        Console.WriteLine(scripture.Reference);
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords[i] != null)
                Console.Write(hiddenWords[i] + " ");
            else
                Console.Write(words[i] + " ");
        }
    }

    private void ClearConsole()
    {
        Console.Clear();
    }
}
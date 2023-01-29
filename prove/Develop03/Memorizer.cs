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
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            HideRandomWords();
            ClearConsole();
            DisplayScripture();
        }
        if (IsScriptureFullyHidden())
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press enter once more or type 'quit' to finish: ");
            Console.ReadLine();
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
        Console.WriteLine();

        int currentLineWidth = 0;
        int maxLineWidth = Console.WindowWidth - 10; // 10 is an arbitrary value to account for margins

        for (int i = 0; i < words.Length; i++)
        {
            string word = hiddenWords[i] != null ? hiddenWords[i] : words[i];
            int nextLineWidth = currentLineWidth + word.Length + 1; // 1 is for the space after the word

            if (nextLineWidth > maxLineWidth)
            {
                Console.WriteLine();
                currentLineWidth = 0;
            }

            Console.Write(word + " ");
            currentLineWidth += word.Length + 1;
        }
    }

    private void ClearConsole()
    {
        Console.Clear();
    }
}
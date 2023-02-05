//This is my Memorizer.cs file

// This class is called Memorizer and is responsible for hiding and displaying random words from a given scripture
class Memorizer
{
    // Private member variables
    private Scripture scripture;
    private string[] words;
    private string[] hiddenWords;
    private Random rand;

    // scripture : an instance of the Scripture class
public Memorizer(Scripture scripture)
{
    this.scripture = scripture;
    words = scripture.Text.GetWords();
    hiddenWords = new string[words.Count()];
    rand = new Random();
}

    // Start function for running the memorization program
    public void Start()
    {
        ClearConsole();
        DisplayScripture();

        // Loop until the scripture is fully hidden
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

    // Function for hiding a random set of words in the scripture
    private void HideRandomWords()
    {
        int remainingWords = hiddenWords.Count(word => word == null);

        // If there are only a few words remaining to be hidden, hide all of them
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

    // Check if all words in scripture have been hidden
    private bool IsScriptureFullyHidden()
    {
        return !hiddenWords.Contains(null);
    }

    // Function for displaying scripture with hidden words
    private void DisplayScripture()
    {
        Console.WriteLine(scripture.Reference);
        Console.WriteLine();

        int currentLineWidth = 0;
        int maxLineWidth = Console.WindowWidth - 10; // 10 is an arbitrary value to account for margins

        // Loop through all words in scripture and display them or their hidden version
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
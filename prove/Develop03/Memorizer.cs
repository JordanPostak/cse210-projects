// Memorizer.cs

// This class is responsible for implementing the logic for a memory game, where a user can hide and display random words from a given scripture.
class Memorizer
{
    // Private member variable to store the scripture object
    private Scripture scripture;
    // Private member variables to store the words and hidden words from the scripture text
    private string[] words;
    private string[] hiddenWords;
    // Private member variable to store a random number generator
    private Random rand;

// Constructor that takes in a scripture object as an argument
// Initializes the words and hiddenWords arrays, and the random number generator
public Memorizer(Scripture scripture)
{
    this.scripture = scripture;
    words = scripture.GetText().GetWords();
    hiddenWords = new string[words.Count()];
    rand = new Random();
}

    // Public function to start the memory game
    public void Start()
    {
        // Clear the console
        ClearConsole();
        // Display the scripture with the words to be memorized
        DisplayScripture();

        // Keep looping until all words in the scripture have been hidden
        while (!IsScriptureFullyHidden())
        {
            // Wait for the user to press enter or type "quit"
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            // If the user types "quit", break out of the loop
            if (input.ToLower() == "quit")
                break;

            // Hide a random set of words from the scripture
            HideRandomWords();
            // Clear the console and display the scripture with hidden words
            ClearConsole();
            DisplayScripture();
        }
        // If all words in the scripture have been hidden, wait for the user to press enter again
        if (IsScriptureFullyHidden())
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press enter once more or type 'quit' to finish: ");
            Console.ReadLine();
        }
    }

    // Private function to hide a random set of words from the scripture
    private void HideRandomWords()
    {
        // Calculate the number of remaining words to be hidden
        int remainingWords = hiddenWords.Count(word => word == null);

        // If there are only a few words remaining, hide all of them
        if (remainingWords <= 3)
        {
            for (int i = 0; i < hiddenWords.Length; i++)
            {
                if (hiddenWords[i] == null)
                {
                    // Replace the word with underscores of the same length
                    hiddenWords[i] = new string('_', words[i].Length);
                    remainingWords--;
                }
            }
        }
        else
        {
            // Otherwise, hide a random number of words (up to half of the remaining words)
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
        Console.WriteLine(scripture.GetReference());
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
    // Clears the console
    private void ClearConsole()
    {
        Console.Clear();
    }
}
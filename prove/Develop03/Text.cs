// Text.cs

class Text
{
    private string text;

    // Constructor that takes in a string representing the text of the scripture
    public Text(string text)
    {
        this.text = text;
    }

    // Property for getting the text value
    public string TextValue
    {
        get { return text; }
    }

    // Method for getting an array of verses from the text
    public string[] GetVerses()
    {
        return text.Split("\n");
    }

    // Method for getting an array of words from the text
    public string[] GetWords()
    {
        string[] verses = GetVerses();
        List<string> words = new List<string>();

        foreach (string verse in verses)
        {
            string[] verseWords = verse.Split(" ");
            words.AddRange(verseWords);
        }

        return words.ToArray();
    }
}
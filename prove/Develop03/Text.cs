// Text.cs

class Text
{
    private string text;
    public Text(string text)
    {
        this.text = text;
    }

    public string TextValue
    {
        get { return text; }
    }

    public string[] GetVerses()
    {
        return text.Split("\n");
    }

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
//This is my Scripture.cs file

class Scripture
{
    private string reference;
    private string text;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    public string Reference
    {
        get { return reference; }
    }

    public string Text
    {
        get { return text; }
    }

    public string[] GetVerses()
    {
        return text.Split("\n");
    }
}

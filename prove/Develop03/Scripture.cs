//This is my Scripture.cs file

class Scripture
{
    // Private member variables
    private string reference;
    private string text;

    // constructor that takes in a reference and text for a scripture
    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    // property for the reference of the scripture
    public string Reference
    {
        get { return reference; }
    }

    // property for the text of the scripture
    public string Text
    {
        get { return text; }
    }

    // method that splits the text of the scripture into an array of verses
    public string[] GetVerses()
    {
        return text.Split("\n");
    }
}

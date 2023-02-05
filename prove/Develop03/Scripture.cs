//This is my Scripture.cs file

class Scripture
{
    // Property for the reference of the scripture
    public Reference Reference { get; set; }

    // Property for the text of the scripture
    public Text Text { get; set; }

    // Constructor that takes in a reference and text for a scripture
    public Scripture(Reference reference, Text text)
    {
        this.Reference = reference;
        this.Text = text;
    }
}

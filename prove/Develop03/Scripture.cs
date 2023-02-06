//Scripture.cs

class Scripture
{
    // Property to store the reference of the scripture, including information such as book, chapter and verse
    private Reference Reference { get; set; }

    // Property to store the text content of the scripture
    private Text Text { get; set; }

    // Constructor to initialize a new scripture object with a given reference and text
    public Scripture(Reference reference, Text text)
    {
        // Assign the reference and text properties with the given parameters
        this.Reference = reference;
        this.Text = text;
    }

    // Getter for the Reference property
    public Reference GetReference()
    {
        return this.Reference;
    }

    // Setter for the Reference property
    public void SetReference(Reference reference)
    {
        this.Reference = reference;
    }

    // Getter for the Text property
    public Text GetText()
    {
        return this.Text;
    }

    // Setter for the Text property
    public void SetText(Text text)
    {
        this.Text = text;
    }
}

//Scripture.cs

class Scripture
{
    // Property to store the reference of the scripture, including information such as book, chapter and verse
    public Reference Reference { get; set; }

    // Property to store the text content of the scripture
    public Text Text { get; set; }

     // Constructor to initialize a new scripture object with a given reference and text
    public Scripture(Reference reference, Text text)
    {
        // Assign the reference and text properties with the given parameters
        this.Reference = reference;
        this.Text = text;
    }
}

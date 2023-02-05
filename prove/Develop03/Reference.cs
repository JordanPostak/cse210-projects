// Reference.cs
class Reference
{
    // Property that holds the value of the reference
    public string Value { get; set; }

    // Constructor that takes in a value and sets it as the value of the reference
    public Reference(string value)
    {
        this.Value = value;
    }
    // Override the ToString method to return the value of the reference as a string
    public override string ToString()
    {
        return Value;
    }
}
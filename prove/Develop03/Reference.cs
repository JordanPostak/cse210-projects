// Reference.cs
class Reference
{
    public string Value { get; set; }

    public Reference(string value)
    {
        this.Value = value;
    }
public override string ToString()
{
    return Value;
}
}
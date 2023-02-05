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
}
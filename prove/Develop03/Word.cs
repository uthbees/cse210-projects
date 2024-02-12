using System.Text.RegularExpressions;

public class Word
{
    private readonly string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
    }

    public void Display()
    {
        if (_hidden)
        {
            Console.Write(Regex.Replace(_text, ".", "_"));
        }
        else
        {
            Console.Write(_text);
        }
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Hide()
    {
        _hidden = true;
    }
}

using System.Text.Json;

public class Entry
{
    private readonly string _response;
    private readonly string _prompt;
    private readonly string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public Entry(string entryJson)
    {
        var deserializedDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(entryJson);

        _prompt = deserializedDictionary["prompt"];
        _response = deserializedDictionary["response"];
        _date = deserializedDictionary["date"];
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
    }

    public string Export()
    {
        return JsonSerializer.Serialize(
            new Dictionary<string, string>
            {
                { "prompt", _prompt },
                { "response", _response },
                { "date", _date }
            }
        );
    }
}

public class Journal
{
    private List<Entry> _entries = new();

    private readonly List<string> _prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I succeed at today?"
    };

    private readonly Random _randomGenerator = new Random();

    public void PromptForNewEntry()
    {
        var prompt = _prompts[_randomGenerator.Next(6)];
        Console.WriteLine(prompt);
        Console.Write("> ");
        var response = Console.ReadLine();

        _entries.Add(new Entry(prompt, response, DateTime.Now.ToShortDateString()));

        Console.WriteLine("Added entry to journal.");
    }

    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }

        Console.WriteLine("End of entries.");
    }

    public void SaveToFile()
    {
        Console.WriteLine("Enter file name to save to:");
        var filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    outputFile.WriteLine(entry.Export());
                }
            }

            Console.WriteLine($"Saved to file {filename}.");
        }
        catch (Exception exception)
        {
            Console.WriteLine("Failed to save to file.");
            Console.WriteLine(exception);
        }
    }

    public void LoadFromFile()
    {
        Console.WriteLine("Enter file name to load from:");
        var filename = Console.ReadLine();

        try
        {
            string[] fileLines = File.ReadAllLines(filename);

            _entries.Clear();
            foreach (var fileLine in fileLines)
            {
                _entries.Add(new Entry(fileLine));
            }

            Console.WriteLine($"Loaded from file {filename}.");
        }
        catch (Exception exception)
        {
            Console.WriteLine("Failed to load from file.");
            Console.WriteLine(exception);
        }
    }
}

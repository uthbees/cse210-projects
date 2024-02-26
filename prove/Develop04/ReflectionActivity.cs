public class ReflectionActivity : Activity
{
    private readonly List<string> _initialPrompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    };

    private readonly List<string> _reflectionPrompts = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    };

    protected override string GetName()
    {
        return "Reflection";
    }

    protected override string GetDescription()
    {
        return
            "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
            "This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    protected override void RunActivityBody(int seconds)
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {Utils.GetRandomListItem(_initialPrompts)} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        Animation.CountDown(5, 1);
        Console.Clear();
        
        Utils.RepeatFunctionForDuration(seconds, () =>
        {
            Console.WriteLine($"> {Utils.GetRandomListItem(_reflectionPrompts)}");
            Animation.ShowSpinner(12);
        });
        
        Console.WriteLine();
    }
}

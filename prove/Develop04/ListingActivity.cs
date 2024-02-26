public class ListingActivity : Activity
{
    private readonly List<string> _initialPrompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };

    protected override string GetName()
    {
        return "Listing";
    }

    protected override string GetDescription()
    {
        return
            "This activity will help you reflect on the good things in your life by having you list as many things as " +
            "you can in a certain area.";
    }

    protected override void RunActivityBody(int seconds)
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {Utils.GetRandomListItem(_initialPrompts)} ---");
        Console.Write("You may begin in: ");
        Animation.CountDown(5, 1);
        Console.WriteLine();

        int responseCount = 0;
        Utils.RepeatFunctionForDuration(seconds, () =>
        {
            Console.Write("> ");
            Console.ReadLine();
            responseCount++;
        });
        Console.WriteLine($"You listed {responseCount} items!");
        Console.WriteLine();
    }
}

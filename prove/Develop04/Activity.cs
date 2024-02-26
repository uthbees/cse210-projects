public class Activity
{
    private void IntroduceActivity()
    {
        Console.WriteLine($"Welcome to the {GetName()} Activity.");
        Console.WriteLine();
        Console.WriteLine(GetDescription());
        Animation.ShowSpinner(2);
    }

    private static void ShowGetReady()
    {
        Console.WriteLine("Get ready...");
        Animation.ShowSpinner(2);
    }

    private void ConcludeActivity(int activityLength)
    {
        Console.WriteLine("Well done!");
        Animation.ShowSpinner(1);
        Console.WriteLine($"You have completed {activityLength} seconds of the {GetName()} activity.");
        Animation.ShowSpinner(2);
    }

    private static int GetActivityLength()
    {
        Console.Write("How long should this activity last? ");
        return Int32.Parse(Console.ReadLine());
    }

    protected virtual void RunActivityBody(int seconds)
    {
    }

    protected virtual string GetName()
    {
        return "Unknown";
    }

    protected virtual string GetDescription()
    {
        return "No description available";
    }

    public void DoActivity()
    {
        Console.Clear();
        IntroduceActivity();
        var activityLength = GetActivityLength();

        Console.Clear();
        ShowGetReady();
        Console.WriteLine();
        RunActivityBody(activityLength);
        ConcludeActivity(activityLength);
    }
}

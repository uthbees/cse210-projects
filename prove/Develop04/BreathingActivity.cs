public class BreathingActivity : Activity
{
    protected override string GetName()
    {
        return "Breathing";
    }

    protected override string GetDescription()
    {
        return
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind " +
            "and focus on your breathing.";
    }

    protected override void RunActivityBody(int seconds)
    {
        Utils.RepeatFunctionForDuration(seconds, () =>
        {
            Console.Write("Breath in... ");
            Animation.CountDown(4, 1);
            Console.WriteLine();

            Console.Write("Now breath out... ");
            Animation.CountDown(6, 1);
            Console.WriteLine();

            Console.WriteLine();
        });
    }
}

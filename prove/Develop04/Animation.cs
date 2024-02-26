public static class Animation
{
    public static void CountDown(int from, int to, int pauseMilliseconds = 1000)
    {
        for (int i = from; i >= to; i--)
        {
            Console.Write(i);
            Thread.Sleep(pauseMilliseconds);
            DeleteLastCharacter();
        }
    }

    public static void ShowSpinner(int seconds)
    {
        ShowSingleCharacterAnimation(new List<char> { '\\', '|', '/', '-' }, seconds);
    }

    public static void ShowSingleCharacterAnimation(List<char> frames, int lengthInSeconds)
    {
        var animationEndTime = DateTime.Now.AddSeconds(lengthInSeconds);

        var currentFrame = -1;

        while (DateTime.Now < animationEndTime)
        {
            currentFrame = (currentFrame + 1) % frames.Count;
            Console.Write(frames[currentFrame]);

            Thread.Sleep(333);

            DeleteLastCharacter();
        }
    }

    public static void DeleteLastCharacter()
    {
        Console.Write("\b \b");
    }
}

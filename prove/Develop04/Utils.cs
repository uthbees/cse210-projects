public static class Utils
{
    public static void RepeatFunctionForDuration(int seconds, Action callback)
    {
        var endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            callback();
        }
    }

    public static T GetRandomListItem<T>(List<T> list)
    {
        var randomGenerator = new Random();

        return list[randomGenerator.Next(list.Count)];
    }
}

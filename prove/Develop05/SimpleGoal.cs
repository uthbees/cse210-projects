public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int reward, bool completed)
    {
        Name = name;
        Description = description;
        Reward = reward;
        _completed = completed;
    }

    public SimpleGoal(string goalData)
    {
        var data = goalData.Split("~~~");
        Name = data[0];
        Description = data[1];
        Reward = int.Parse(data[2]);
        _completed = bool.Parse(data[3]);
    }

    public override string Export()
    {
        return $"Simple~~~{Name}~~~{Description}~~~{Reward}~~~{_completed}";
    }

    public override bool IsCompleted()
    {
        return _completed;
    }

    public override void MarkCompletion()
    {
        _completed = true;
    }
}

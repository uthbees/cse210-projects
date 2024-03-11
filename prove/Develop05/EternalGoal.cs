public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int reward)
    {
        Name = name;
        Description = description;
        Reward = reward;
    }

    public EternalGoal(string goalData)
    {
        var data = goalData.Split("~~~");
        Name = data[0];
        Description = data[1];
        Reward = int.Parse(data[2]);
    }

    public override string Export()
    {
        return $"Eternal~~~{Name}~~~{Description}~~~{Reward}";
    }

    public override bool IsCompleted()
    {
        return false;
    }
}

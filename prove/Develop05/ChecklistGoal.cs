public class ChecklistGoal : Goal
{
    private readonly int _bonus;
    private int _completions;
    private readonly int _requiredCompletions;

    public ChecklistGoal(string name, string description, int reward, int bonus, int completions,
        int requiredCompletions)
    {
        Name = name;
        Description = description;
        Reward = reward;
        _bonus = bonus;
        _completions = completions;
        _requiredCompletions = requiredCompletions;
    }

    public ChecklistGoal(string goalData)
    {
        var data = goalData.Split("~~~");
        Name = data[0];
        Description = data[1];
        Reward = int.Parse(data[2]);
        _bonus = int.Parse(data[3]);
        _completions = int.Parse(data[4]);
        _requiredCompletions = int.Parse(data[5]);
    }

    public override string Export()
    {
        return $"Checklist~~~{Name}~~~{Description}~~~{Reward}~~~{_bonus}~~~{_completions}~~~{_requiredCompletions}";
    }

    public override bool IsCompleted()
    {
        return _completions >= _requiredCompletions;
    }

    public override void MarkCompletion()
    {
        _completions++;
    }

    public override string GetDisplayString()
    {
        return base.GetDisplayString() + $" -- Currently completed: {_completions}/{_requiredCompletions}";
    }

    public override int GetNextReward()
    {
        if (_completions == _requiredCompletions - 1)
        {
            return Reward + _bonus;
        }

        return base.GetNextReward();
    }
}

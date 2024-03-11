public abstract class Goal
{
    protected int Reward;
    protected string Name;
    protected string Description;

    public string GetName()
    {
        return Name;
    }

    public abstract string Export();
    public abstract bool IsCompleted();

    public virtual void MarkCompletion()
    {
    }

    public virtual string GetDisplayString()
    {
        var checkboxFilling = IsCompleted() ? "X" : " ";
        return $"[{checkboxFilling}] {Name} ({Description})";
    }

    public virtual int GetNextReward()
    {
        return IsCompleted() ? 0 : Reward;
    }
}

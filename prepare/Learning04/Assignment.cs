namespace Learning04;

public class Assignment
{
    protected readonly string StudentName;
    private readonly string _topic;

    public Assignment(string studentName, string topic)
    {
        StudentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return StudentName + " - " + _topic;
    }
}

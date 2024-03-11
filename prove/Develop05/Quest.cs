public class Quest
{
    private int _points = 0;
    private readonly List<Goal> _goals = new();

    public void SaveToFile(string filename)
    {
        using var outputFile = new StreamWriter(filename);
        
        outputFile.WriteLine(_points);
        foreach (var goal in _goals)
        {
            outputFile.WriteLine(goal.Export());
        }
    }

    public void LoadFromFile(string filename)
    {
        var lines = File.ReadAllLines(filename);
        _goals.Clear();
        _points = int.Parse(lines[0]);
        
        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split("~~~", 2);
            var goalType = data[0];
            var goalData = data[1];

            switch (goalType)
            {
                case "Simple":
                    _goals.Add(new SimpleGoal(goalData));
                    break;
                case "Eternal":
                    _goals.Add(new EternalGoal(goalData));
                    break;
                case "Checklist":
                    _goals.Add(new ChecklistGoal(goalData));
                    break;
                default:
                    throw new Exception("Deserialization failed!");
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"You have {_points} points.");
    }

    public enum GoalDisplayFormat
    {
        AllInfo,
        Simple
    }

    public void DisplayGoals(GoalDisplayFormat format = GoalDisplayFormat.AllInfo)
    {
        if (_goals.Count > 0)
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                var goal = _goals[i];

                switch (format)
                {
                    case GoalDisplayFormat.AllInfo:
                        Console.WriteLine($"{i + 1}. {goal.GetDisplayString()}");
                        break;
                    case GoalDisplayFormat.Simple:
                        Console.WriteLine($"{i + 1}. {goal.GetName()}");
                        break;
                    default:
                        throw new Exception("Invalid goal display format!");
                }
            }
        }
        else
        {
            Console.WriteLine("There are no goals.");
        }
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        var goalType = int.Parse(Console.ReadLine());
        Console.Write("What is the name of your goal? ");
        var goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        var goalDescription = Console.ReadLine();
        Console.Write("How many points is this goal worth? ");
        var goalReward = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                _goals.Add(new SimpleGoal(goalName, goalDescription, goalReward, false));
                break;
            case 2:
                _goals.Add(new EternalGoal(goalName, goalDescription, goalReward));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                var goalBonusRequirement = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                var goalBonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(goalName, goalDescription, goalReward, goalBonus, 0,
                    goalBonusRequirement));
                break;
            default:
                throw new Exception("Invalid goal type!");
        }
    }

    public void AccomplishGoal()
    {
        DisplayGoals(GoalDisplayFormat.Simple);
        Console.Write("Which goal did you accomplish? ");
        var goalNumber = int.Parse(Console.ReadLine());
        var selectedGoal = _goals[goalNumber - 1];

        if (!selectedGoal.IsCompleted())
        {
            var reward = selectedGoal.GetNextReward();
            _points += reward;
            selectedGoal.MarkCompletion();
            Console.WriteLine($"Congratulations! You have earned {reward} points!");
            Console.WriteLine($"You now have {_points} points.");
        }
        else
        {
            Console.WriteLine("That goal has already been completed!");
        }
    }
}

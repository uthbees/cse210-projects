using Learning04;

class Program
{
    static void Main(string[] args)
    {
        var baseAssignment = new Assignment("John Doe", "Programming With Classes");
        Console.WriteLine(baseAssignment.GetSummary());

        Console.WriteLine();
            
        var writingAssignment = new WritingAssignment("Brian Smith", "History", "The Hungarian Empire");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
        
        Console.WriteLine();

        var mathAssignment = new MathAssignment("John Smith", "Algebra", "3.4", "11-15");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
    }
}

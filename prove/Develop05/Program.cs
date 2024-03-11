class Program
{
    static void Main(string[] args)
    {
        var quest = new Quest();

        var inMenu = true;

        while (inMenu)
        {
            Console.WriteLine();
            quest.DisplayScore();
            Console.WriteLine();
            DisplayMenu();
            Console.Write("Select a choice from the menu: ");
            var choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    quest.CreateNewGoal();
                    break;
                case 2:
                    quest.DisplayGoals();
                    break;
                case 3:
                {
                    Console.Write("What is the filename for the goal file? ");
                    var filename = Console.ReadLine();
                    quest.SaveToFile(filename);
                    break;
                }
                case 4:
                {
                    Console.Write("What is the filename for the goal file? ");
                    var filename = Console.ReadLine();
                    quest.LoadFromFile(filename);
                    break;
                }
                case 5:
                    quest.AccomplishGoal();
                    break;
                case 6:
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
    }
}

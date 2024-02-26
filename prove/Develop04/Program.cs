class Program
{
    static void Main(string[] args)
    {
        var breathingActivity = new BreathingActivity();
        var reflectionActivity = new ReflectionActivity();
        var listingActivity = new ListingActivity();

        bool inMenu = true;

        while (inMenu)
        {
            Console.Clear();
            DisplayMenu();
            Console.Write("Select a choice from the menu: ");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    breathingActivity.DoActivity();
                    break;
                case 2:
                    reflectionActivity.DoActivity();
                    break;
                case 3:
                    listingActivity.DoActivity();
                    break;
                case 4:
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Not an option, try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
    }
}

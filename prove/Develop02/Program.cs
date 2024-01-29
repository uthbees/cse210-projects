class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();

        var menu = new Menu(new List<Menu.MenuItem>
        {
            new("1", "Write", () =>
            {
                journal.PromptForNewEntry();
                return null;
            }),
            new("2", "Display", () =>
            {
                journal.Display();
                return null;
            }),
            new("3", "Load", () =>
            {
                journal.LoadFromFile();
                return null;
            }),
            new("4", "Save", () =>
            {
                journal.SaveToFile();
                return null;
            }),
            new("5", "Quit",
                () => new List<Menu.MenuCommand>
                {
                    Menu.MenuCommand.LeaveMenu,
                    Menu.MenuCommand.SkipPostActionPrompt
                }),
        });

        menu.Run();
    }
}

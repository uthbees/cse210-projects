public class Menu
{
    public enum MenuCommand
    {
        LeaveMenu,
        SkipPostActionPrompt
    }

    public struct MenuItem
    {
        public string ItemKey { get; }
        public string ItemDescription { get; }
        public Func<List<MenuCommand>> ItemAction { get; }

        public MenuItem(string itemKey, string itemDescription, Func<List<MenuCommand>> itemAction)
        {
            ItemKey = itemKey;
            ItemDescription = itemDescription;
            ItemAction = itemAction;
        }
    }

    private readonly List<MenuItem> _menuItems;

    public Menu(List<MenuItem> menuItems)
    {
        _menuItems = menuItems;
    }

    public void Run()
    {
        Console.Clear();

        var running = true;
        var skipNextPostActionPrompt = false;
        while (running)
        {
            DisplayMenu();
            var request = Console.ReadLine();
            Console.Clear();

            var requestedItemIndex = _menuItems.FindIndex(item => item.ItemKey == request);

            if (requestedItemIndex == -1)
            {
                Console.WriteLine("Invalid command, try again.");
            }
            else
            {
                var requestedAction = _menuItems[requestedItemIndex].ItemAction;
                var requestedCommands = requestedAction();

                if (requestedCommands != null)
                {
                    if (requestedCommands.Contains(MenuCommand.LeaveMenu))
                    {
                        running = false;
                    }

                    if (requestedCommands.Contains(MenuCommand.SkipPostActionPrompt))
                    {
                        skipNextPostActionPrompt = true;
                    }
                }
            }

            if (skipNextPostActionPrompt)
            {
                skipNextPostActionPrompt = false;
            }
            else
            {
                Console.ReadLine();
            }

            Console.Clear();
        }

        void DisplayMenu()
        {
            Console.WriteLine("Enter a command:");

            foreach (var menuItem in _menuItems)
            {
                Console.WriteLine($"\t{menuItem.ItemKey}. {menuItem.ItemDescription}");
            }
        }
    }
}

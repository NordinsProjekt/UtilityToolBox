using Services.Factories.Types;

namespace Services.Factories.Helpers;

public static class MenuHelper
{
    public static void DisplayMenu(string heading, List<string> menuItems, MenuDirection direction)
    {
        Console.WriteLine(heading);
        Console.WriteLine(new string('-', heading.Length));

        switch (direction)
        {
            case MenuDirection.Vertical:
            {
                foreach (var item in menuItems) Console.WriteLine(item);
                break;
            }
            case MenuDirection.Horizontal:
                Console.WriteLine(string.Join(" | ", menuItems));
                break;
        }
    }
}

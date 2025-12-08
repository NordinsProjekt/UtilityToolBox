using Services.Factories.Interfaces;
using Services.Factories.Types;

namespace Services.Factories.Helpers;

/// <summary>
/// Provides helper methods for menu operations.
/// </summary>
public static class MenuHelper
{
    /// <summary>
    /// Displays a menu with the specified heading, items, options, and direction.
    /// </summary>
    /// <param name="heading">The menu heading to display.</param>
    /// <param name="menuItems">The list of menu items to display.</param>
    /// <param name="menuOptions">The list of menu options/keys corresponding to each item.</param>
    /// <param name="direction">The direction to display the menu (Vertical or Horizontal).</param>
    public static void DisplayMenu(string heading, List<string> menuItems, List<string> menuOptions, MenuDirection direction)
    {
        Console.WriteLine(heading);
        Console.WriteLine(new string('-', heading.Length));

        switch (direction)
        {
            case MenuDirection.Vertical:
            {
                for (var i = 0; i < menuItems.Count; i++)
                {
                    Console.WriteLine("[{0}] {1}", menuOptions[i], menuItems[i]);
                }
                break;
            }
            
            case MenuDirection.Horizontal:

                for (var i = 0; i < menuItems.Count; i++)
                {
                    Console.Write("[{0}] {1}", menuOptions[i], menuItems[i]);
                    if (i+1 != menuItems.Count)
                        Console.Write(" | ");
                }
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    /// <summary>
    /// Automatically adds numbered menu options (1, 2, 3, ...) to the menu based on the number of menu items.
    /// </summary>
    /// <param name="menu">The menu to add options to.</param>
    public static void AddMenuOptions(IMenu menu)
    {
        for (var i = 1; i <= menu.MenuItems.Count; i++)
        {
            menu.MenuOption.Add(i.ToString());
        }
    }
}

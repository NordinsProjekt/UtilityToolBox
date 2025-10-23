using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Factories.Interfaces.Extensions;

public static class MenuExtensions
{
    public static IMenu AddMenuItem(this IMenu menu, string itemName)
    {
        menu.MenuItems.Add(itemName);
        return menu;
    }

    public static IMenu RemoveMenuItem(this IMenu menu, string itemName)
    {
        var foundItem = menu.MenuItems.Remove(itemName);
        if (!foundItem) throw new ArgumentException($"Menu item '{itemName}' not found.");

        return menu;
    }

    public static IMenu ClearMenuItems(this IMenu menu)
    {
        menu.MenuItems.Clear();

        return menu;
    }
}

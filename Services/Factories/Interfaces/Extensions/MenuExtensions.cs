namespace Services.Factories.Interfaces.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IMenu"/> to support fluent API operations.
/// </summary>
public static class MenuExtensions
{
    /// <summary>
    /// Adds a menu item to the menu.
    /// </summary>
    /// <param name="menu">The menu to add the item to.</param>
    /// <param name="itemName">The name of the menu item to add.</param>
    /// <returns>The menu instance for fluent chaining.</returns>
    public static IMenu AddMenuItem(this IMenu menu, string itemName)
    {
        menu.MenuItems.Add(itemName);
        return menu;
    }

    /// <summary>
    /// Removes a menu item from the menu.
    /// </summary>
    /// <param name="menu">The menu to remove the item from.</param>
    /// <param name="itemName">The name of the menu item to remove.</param>
    /// <returns>The menu instance for fluent chaining.</returns>
    /// <exception cref="ArgumentException">Thrown when the menu item is not found.</exception>
    public static IMenu RemoveMenuItem(this IMenu menu, string itemName)
    {
        var foundItem = menu.MenuItems.Remove(itemName);
        return !foundItem ? throw new ArgumentException($"Menu item '{itemName}' not found.") : menu;
    }

    /// <summary>
    /// Clears all menu items from the menu.
    /// </summary>
    /// <param name="menu">The menu to clear items from.</param>
    /// <returns>The menu instance for fluent chaining.</returns>
    public static IMenu ClearMenuItems(this IMenu menu)
    {
        menu.MenuItems.Clear();
        return menu;
    }
}
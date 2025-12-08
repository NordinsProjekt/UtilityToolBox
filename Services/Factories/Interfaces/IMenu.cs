namespace Services.Factories.Interfaces;

/// <summary>
/// Represents a menu with items and display capabilities.
/// </summary>
public interface IMenu
{
    /// <summary>
    /// Gets or sets the menu heading.
    /// </summary>
    string Heading { get; set; }
    
    /// <summary>
    /// Gets or sets the list of menu items to display.
    /// </summary>
    List<string> MenuItems { get; set; }
    
    /// <summary>
    /// Gets or sets the list of menu options/keys corresponding to each menu item.
    /// </summary>
    List<string> MenuOption { get; set; }

    /// <summary>
    /// Displays the menu to the console.
    /// </summary>
    void ShowMenu();
}
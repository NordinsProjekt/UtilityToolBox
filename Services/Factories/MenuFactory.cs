using Services.Factories.Interfaces;
using Services.Factories.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Factories.Classes;

namespace Services.Factories;

/// <summary>
/// Factory for creating menu instances.
/// </summary>
public static class MenuFactory
{
    /// <summary>
    /// Creates a menu of the specified type and direction.
    /// </summary>
    /// <param name="menuType">The type of menu to create (Main, Settings, or Help).</param>
    /// <param name="direction">The display direction for the menu (Vertical or Horizontal).</param>
    /// <returns>An instance of <see cref="IMenu"/> configured with the specified type and direction.</returns>
    /// <exception cref="ArgumentException">Thrown when an invalid menu type is provided.</exception>
    public static IMenu CreateMenu(MenuType menuType, MenuDirection direction)
    {
        return menuType switch
        {
            MenuType.Main => new MainMenu(direction),
            MenuType.Settings => new SettingsMenu(direction),
            MenuType.Help => new HelpMenu(direction),
            _ => throw new ArgumentException("Invalid menu type"),
        };
    }
}
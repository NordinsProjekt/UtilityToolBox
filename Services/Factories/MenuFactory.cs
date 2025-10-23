using Services.Factories.Interfaces;
using Services.Factories.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Factories;

public class MenuFactory
{
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
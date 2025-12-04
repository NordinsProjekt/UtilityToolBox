using Services.Factories;
using Services.Factories.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityToolBox.Menu;

public static class VerticalMainMenu
{
    public static void ShowMenu()
    {
        var menu = MenuFactory.CreateMenu(MenuType.Main, MenuDirection.Vertical);
        menu.Heading = "Main Menu";
        menu.MenuItems.AddRange("Add Product", "Update Product", "Delete Product");

        menu.ShowMenu();
    }
}

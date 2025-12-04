using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Factories;
using Services.Factories.Types;

namespace UtilityToolBox.Menu;

public static class HorizontalMainMenu
{
    public static void ShowMenu()
    {
        var menu = MenuFactory.CreateMenu(MenuType.Main, MenuDirection.Horizontal);
        menu.Heading = "Main Menu";
        menu.MenuItems.AddRange("Add Product", "Update Product", "Delete Product");
        
        menu.ShowMenu();
    }
}

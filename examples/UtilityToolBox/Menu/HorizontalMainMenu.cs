using Services.Factories;
using Services.Factories.Helpers;
using Services.Factories.Types;

namespace UtilityToolBox.Menu;

public static class HorizontalMainMenu
{
    public static void ShowMenu()
    {
        var menu = MenuFactory.CreateMenu(MenuType.Main, MenuDirection.Horizontal);
        menu.Heading = "Main Menu";
        menu.MenuItems.AddRange(new[] { "Add Product", "Update Product", "Delete Product" });
        
        MenuHelper.AddMenuOptions(menu);
        menu.ShowMenu();
    }
}

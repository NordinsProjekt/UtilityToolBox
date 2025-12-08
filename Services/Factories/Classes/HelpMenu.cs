using Services.Factories.Helpers;
using Services.Factories.Interfaces;
using Services.Factories.Types;

namespace Services.Factories.Classes;

internal class HelpMenu : IMenu
{
    private MenuDirection _direction;
    public string Heading { get; set; }
    public List<string> MenuItems { get; set; }
    public List<string> MenuOption { get; set; }

    public void ShowMenu()
    {
        MenuHelper.DisplayMenu(Heading, MenuItems, MenuOption, _direction);
    }

    internal HelpMenu(MenuDirection direction)
    {
        _direction = direction;
        MenuItems = [];
        MenuOption = [];
    }
}
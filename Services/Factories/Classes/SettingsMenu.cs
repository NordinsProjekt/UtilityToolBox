using Services.Factories.Helpers;
using Services.Factories.Interfaces;
using Services.Factories.Types;

namespace Services.Factories.Classes;

internal class SettingsMenu : IMenu
{
    private MenuDirection _direction;

    public string Heading { get; set; }
    public List<string> MenuItems { get; set; }
    public List<string> MenuOption { get; set; }

    public void ShowMenu()
    {
        MenuHelper.DisplayMenu(Heading, MenuItems, MenuOption, _direction);
    }

    internal SettingsMenu(MenuDirection direction)
    {
        _direction = direction;
        MenuItems = [];
        MenuOption = [];
    }
}
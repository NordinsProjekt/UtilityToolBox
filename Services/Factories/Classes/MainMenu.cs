using Services.Factories.Interfaces;
using Services.Factories.Types;

namespace Services.Factories.Classes;

public class MainMenu : IMenu
{
    private MenuDirection _direction;

    public List<string> MenuItems { get; set; }

    internal MainMenu(MenuDirection direction)
    {
        _direction = direction;
        MenuItems = [];
    }
}
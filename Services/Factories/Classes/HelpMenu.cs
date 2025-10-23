using Services.Factories.Interfaces;
using Services.Factories.Types;

namespace Services.Factories.Classes;

public class HelpMenu : IMenu
{
    private MenuDirection _direction;
    public List<string> MenuItems { get; set; }

    internal HelpMenu(MenuDirection direction)
    {
        _direction = direction;
        MenuItems = [];
    }
}
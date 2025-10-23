using Services.Factories.Interfaces;
using Services.Factories.Types;

namespace Services.Factories.Classes;

public class SettingsMenu : IMenu
{
    private MenuDirection _direction;

    internal SettingsMenu(MenuDirection direction)
    {
        _direction = direction;
    }
}
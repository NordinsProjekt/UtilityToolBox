namespace Services.Factories.Interfaces;

public interface IMenu
{
    public string Heading { get; set; }
    public List<string> MenuItems { get; set; }

    public void ShowMenu();
}
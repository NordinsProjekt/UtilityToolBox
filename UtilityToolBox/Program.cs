using UtilityToolBox.Menu;

namespace UtilityToolBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Horizontal MainMenu");
            HorizontalMainMenu.ShowMenu();
            
            Console.WriteLine("\nVertical MainMenu");
            VerticalMainMenu.ShowMenu();
        }
    }
}

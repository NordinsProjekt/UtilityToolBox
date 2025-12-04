using Services.Factories;
using Services.Factories.Classes;
using Services.Factories.Types;

namespace ServiceTests.Factories;

public class MenuFactoryTests
{
    [Fact]
    public void CreateMenu_WithMainMenuTypeAndHorizontalDirection_ReturnsMainMenu()
    {
        // Arrange
        var menuType = MenuType.Main;
        var direction = MenuDirection.Horizontal;

        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<MainMenu>(result);
        Assert.NotNull(result.MenuItems);
        Assert.Empty(result.MenuItems);
    }

    [Fact]
    public void CreateMenu_WithMainMenuTypeAndVerticalDirection_ReturnsMainMenu()
    {
        // Arrange
        var menuType = MenuType.Main;
        var direction = MenuDirection.Vertical;

        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<MainMenu>(result);
        Assert.NotNull(result.MenuItems);
        Assert.Empty(result.MenuItems);
    }

    [Fact]
    public void CreateMenu_WithSettingsMenuTypeAndHorizontalDirection_ReturnsSettingsMenu()
    {
        // Arrange
        var menuType = MenuType.Settings;
        var direction = MenuDirection.Horizontal;

        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<SettingsMenu>(result);
        Assert.NotNull(result.MenuItems);
        Assert.Empty(result.MenuItems);
    }

    [Fact]
    public void CreateMenu_WithSettingsMenuTypeAndVerticalDirection_ReturnsSettingsMenu()
    {
        // Arrange
        var menuType = MenuType.Settings;
        var direction = MenuDirection.Vertical;

        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<SettingsMenu>(result);
        Assert.NotNull(result.MenuItems);
        Assert.Empty(result.MenuItems);
    }

    [Fact]
    public void CreateMenu_WithHelpMenuTypeAndHorizontalDirection_ReturnsHelpMenu()
    {
        // Arrange
        var menuType = MenuType.Help;
        var direction = MenuDirection.Horizontal;

        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<HelpMenu>(result);
        Assert.NotNull(result.MenuItems);
        Assert.Empty(result.MenuItems);
    }

    [Fact]
    public void CreateMenu_WithHelpMenuTypeAndVerticalDirection_ReturnsHelpMenu()
    {
        // Arrange
        var menuType = MenuType.Help;
        var direction = MenuDirection.Vertical;

        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<HelpMenu>(result);
        Assert.NotNull(result.MenuItems);
        Assert.Empty(result.MenuItems);
    }

    [Fact]
    public void CreateMenu_WithInvalidMenuType_ThrowsArgumentException()
    {
        // Arrange
        var invalidMenuType = (MenuType)999;
        var direction = MenuDirection.Horizontal;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            MenuFactory.CreateMenu(invalidMenuType, direction));
        Assert.Equal("Invalid menu type", exception.Message);
    }

    [Theory]
    [InlineData(MenuType.Main, MenuDirection.Horizontal)]
    [InlineData(MenuType.Main, MenuDirection.Vertical)]
    [InlineData(MenuType.Settings, MenuDirection.Horizontal)]
    [InlineData(MenuType.Settings, MenuDirection.Vertical)]
    [InlineData(MenuType.Help, MenuDirection.Horizontal)]
    [InlineData(MenuType.Help, MenuDirection.Vertical)]
    public void CreateMenu_WithAllValidCombinations_ReturnsNonNullMenu(MenuType menuType, MenuDirection direction)
    {
        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.MenuItems);
    }

    [Theory]
    [InlineData(MenuType.Main, typeof(MainMenu))]
    [InlineData(MenuType.Settings, typeof(SettingsMenu))]
    [InlineData(MenuType.Help, typeof(HelpMenu))]
    public void CreateMenu_WithEachMenuType_ReturnsCorrectMenuImplementation(MenuType menuType, Type expectedType)
    {
        // Arrange
        var direction = MenuDirection.Horizontal;

        // Act
        var result = MenuFactory.CreateMenu(menuType, direction);

        // Assert
        Assert.IsType(expectedType, result);
    }
}

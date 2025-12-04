using Services.Factories.Interfaces;
using Services.Factories.Interfaces.Extensions;

namespace ServiceTests.Factories.Interfaces.Extensions;

public class MenuExtensionsTests
{
    private class TestMenu : IMenu
    {
        public string Heading { get; set; } = string.Empty;
        public List<string> MenuItems { get; set; } = [];
        public void ShowMenu() { }
    }

    [Fact]
    public void AddMenuItem_WithValidItemName_AddsItemToMenu()
    {
        // Arrange
        var menu = new TestMenu();
        var itemName = "File";

        // Act
        var result = menu.AddMenuItem(itemName);

        // Assert
        Assert.NotNull(result);
        Assert.Single(menu.MenuItems);
        Assert.Contains(itemName, menu.MenuItems);
    }

    [Fact]
    public void AddMenuItem_WithMultipleItems_AddsAllItemsToMenu()
    {
        // Arrange
        var menu = new TestMenu();

        // Act
        var result = menu.AddMenuItem("File")
                         .AddMenuItem("Edit")
                         .AddMenuItem("View");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, menu.MenuItems.Count);
        Assert.Contains("File", menu.MenuItems);
        Assert.Contains("Edit", menu.MenuItems);
        Assert.Contains("View", menu.MenuItems);
    }

    [Fact]
    public void AddMenuItem_ReturnsMenuInstance_AllowsFluentChaining()
    {
        // Arrange
        var menu = new TestMenu();

        // Act
        var result = menu.AddMenuItem("Item1");

        // Assert
        Assert.Same(menu, result);
    }

    [Fact]
    public void AddMenuItem_WithEmptyString_AddsEmptyStringToMenu()
    {
        // Arrange
        var menu = new TestMenu();
        var itemName = "";

        // Act
        var result = menu.AddMenuItem(itemName);

        // Assert
        Assert.NotNull(result);
        Assert.Single(menu.MenuItems);
        Assert.Contains("", menu.MenuItems);
    }

    [Theory]
    [InlineData("File")]
    [InlineData("Edit")]
    [InlineData("View")]
    [InlineData("Help")]
    public void AddMenuItem_WithDifferentItemNames_AddsCorrectItem(string itemName)
    {
        // Arrange
        var menu = new TestMenu();

        // Act
        menu.AddMenuItem(itemName);

        // Assert
        Assert.Contains(itemName, menu.MenuItems);
    }

    [Fact]
    public void RemoveMenuItem_WithExistingItem_RemovesItemFromMenu()
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");
        menu.MenuItems.Add("Edit");
        var itemToRemove = "File";

        // Act
        var result = menu.RemoveMenuItem(itemToRemove);

        // Assert
        Assert.NotNull(result);
        Assert.Single(menu.MenuItems);
        Assert.DoesNotContain(itemToRemove, menu.MenuItems);
        Assert.Contains("Edit", menu.MenuItems);
    }

    [Fact]
    public void RemoveMenuItem_WithNonExistingItem_ThrowsArgumentException()
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");
        var nonExistingItem = "Edit";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            menu.RemoveMenuItem(nonExistingItem));
        Assert.Equal($"Menu item '{nonExistingItem}' not found.", exception.Message);
    }

    [Fact]
    public void RemoveMenuItem_FromEmptyMenu_ThrowsArgumentException()
    {
        // Arrange
        var menu = new TestMenu();
        var itemName = "File";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            menu.RemoveMenuItem(itemName));
        Assert.Equal($"Menu item '{itemName}' not found.", exception.Message);
    }

    [Fact]
    public void RemoveMenuItem_ReturnsMenuInstance_AllowsFluentChaining()
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");

        // Act
        var result = menu.RemoveMenuItem("File");

        // Assert
        Assert.Same(menu, result);
    }

    [Fact]
    public void RemoveMenuItem_WithMultipleItems_RemovesOnlySpecifiedItem()
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");
        menu.MenuItems.Add("Edit");
        menu.MenuItems.Add("View");

        // Act
        menu.RemoveMenuItem("Edit");

        // Assert
        Assert.Equal(2, menu.MenuItems.Count);
        Assert.Contains("File", menu.MenuItems);
        Assert.DoesNotContain("Edit", menu.MenuItems);
        Assert.Contains("View", menu.MenuItems);
    }

    [Theory]
    [InlineData("File")]
    [InlineData("Edit")]
    [InlineData("View")]
    public void RemoveMenuItem_WithDifferentExistingItems_RemovesCorrectItem(string itemToRemove)
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");
        menu.MenuItems.Add("Edit");
        menu.MenuItems.Add("View");

        // Act
        menu.RemoveMenuItem(itemToRemove);

        // Assert
        Assert.DoesNotContain(itemToRemove, menu.MenuItems);
        Assert.Equal(2, menu.MenuItems.Count);
    }

    [Fact]
    public void ClearMenuItems_WithItemsInMenu_RemovesAllItems()
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");
        menu.MenuItems.Add("Edit");
        menu.MenuItems.Add("View");

        // Act
        var result = menu.ClearMenuItems();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(menu.MenuItems);
    }

    [Fact]
    public void ClearMenuItems_WithEmptyMenu_KeepsMenuEmpty()
    {
        // Arrange
        var menu = new TestMenu();

        // Act
        var result = menu.ClearMenuItems();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(menu.MenuItems);
    }

    [Fact]
    public void ClearMenuItems_ReturnsMenuInstance_AllowsFluentChaining()
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");

        // Act
        var result = menu.ClearMenuItems();

        // Assert
        Assert.Same(menu, result);
    }

    [Fact]
    public void ClearMenuItems_WithSingleItem_RemovesItem()
    {
        // Arrange
        var menu = new TestMenu();
        menu.MenuItems.Add("File");

        // Act
        menu.ClearMenuItems();

        // Assert
        Assert.Empty(menu.MenuItems);
    }

    [Fact]
    public void MenuExtensions_FluentChaining_WorksCorrectly()
    {
        // Arrange
        var menu = new TestMenu();

        // Act
        menu.AddMenuItem("File")
            .AddMenuItem("Edit")
            .AddMenuItem("View")
            .RemoveMenuItem("Edit")
            .AddMenuItem("Help");

        // Assert
        Assert.Equal(3, menu.MenuItems.Count);
        Assert.Contains("File", menu.MenuItems);
        Assert.DoesNotContain("Edit", menu.MenuItems);
        Assert.Contains("View", menu.MenuItems);
        Assert.Contains("Help", menu.MenuItems);
    }

    [Fact]
    public void MenuExtensions_ComplexFluentChaining_WorksCorrectly()
    {
        // Arrange
        var menu = new TestMenu();

        // Act
        menu.AddMenuItem("File")
            .AddMenuItem("Edit")
            .AddMenuItem("View")
            .ClearMenuItems()
            .AddMenuItem("New Item");

        // Assert
        Assert.Single(menu.MenuItems);
        Assert.Contains("New Item", menu.MenuItems);
    }
}

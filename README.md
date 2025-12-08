# UtilityToolBox.Services

[![Build and Publish NuGet](https://github.com/NordinsProjekt/UtilityToolBox/actions/workflows/build-and-publish.yml/badge.svg)](https://github.com/NordinsProjekt/UtilityToolBox/actions/workflows/build-and-publish.yml)
[![NuGet](https://img.shields.io/nuget/v/UtilityToolBox.Services.svg)](https://www.nuget.org/packages/UtilityToolBox.Services/)

A .NET library for creating and managing console menus with a fluent API.

## Features

- ?? **Factory Pattern** - Create menus easily with `MenuFactory`
- ?? **Fluent API** - Chain operations for intuitive menu building
- ?? **Multiple Layouts** - Support for vertical and horizontal menu display
- ?? **Multiple Menu Types** - Main, Settings, and Help menus out of the box
- ?? **Extension Methods** - Extend menu functionality seamlessly
- ?? **Well Tested** - Comprehensive unit test coverage

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package UtilityToolBox.Services
```

Or via Package Manager Console:

```powershell
Install-Package UtilityToolBox.Services
```

## Quick Start

```csharp
using Services.Factories;
using Services.Factories.Helpers;
using Services.Factories.Interfaces.Extensions;
using Services.Factories.Types;

// Create a menu
var menu = MenuFactory.CreateMenu(MenuType.Main, MenuDirection.Vertical);

// Set heading
menu.Heading = "Main Menu";

// Add items using fluent API
menu.AddMenuItem("New File")
    .AddMenuItem("Open File")
    .AddMenuItem("Save")
    .AddMenuItem("Exit");

// Add numbered options
MenuHelper.AddMenuOptions(menu);

// Display the menu
menu.ShowMenu();
```

Output:
```
Main Menu
---------
[1] New File
[2] Open File
[3] Save
[4] Exit
```

## Usage Examples

### Horizontal Menu

```csharp
var menu = MenuFactory.CreateMenu(MenuType.Settings, MenuDirection.Horizontal);
menu.Heading = "Settings";
menu.MenuItems.AddRange(new[] { "Display", "Audio", "Controls" });
MenuHelper.AddMenuOptions(menu);
menu.ShowMenu();
```

Output:
```
Settings
--------
[1] Display | [2] Audio | [3] Controls
```

### Fluent API

```csharp
var menu = MenuFactory.CreateMenu(MenuType.Help, MenuDirection.Vertical);
menu.Heading = "Help Topics"
    .AddMenuItem("Getting Started")
    .AddMenuItem("Documentation")
    .AddMenuItem("Support")
    .RemoveMenuItem("Support")  // Changed our mind
    .AddMenuItem("Contact Us");

MenuHelper.AddMenuOptions(menu);
menu.ShowMenu();
```

### Menu Types

Three menu types are available:

- `MenuType.Main` - For main application menus
- `MenuType.Settings` - For configuration menus
- `MenuType.Help` - For help and support menus

### Display Directions

- `MenuDirection.Vertical` - Items displayed one per line
- `MenuDirection.Horizontal` - Items displayed side by side with separators

## API Reference

### MenuFactory

```csharp
public static IMenu CreateMenu(MenuType menuType, MenuDirection direction)
```

Creates a new menu instance.

### IMenu Interface

```csharp
public interface IMenu
{
    string Heading { get; set; }
    List<string> MenuItems { get; set; }
    List<string> MenuOption { get; set; }
    void ShowMenu();
}
```

### MenuExtensions

```csharp
public static IMenu AddMenuItem(this IMenu menu, string itemName)
public static IMenu RemoveMenuItem(this IMenu menu, string itemName)
public static IMenu ClearMenuItems(this IMenu menu)
```

### MenuHelper

```csharp
public static void AddMenuOptions(IMenu menu)
public static void DisplayMenu(string heading, List<string> menuItems, 
                               List<string> menuOptions, MenuDirection direction)
```

## Examples

Check out the [examples](./examples) directory for complete working samples.

## Building from Source

```bash
# Clone the repository
git clone https://github.com/NordinsProjekt/UtilityToolBox.git
cd UtilityToolBox

# Restore dependencies
dotnet restore

# Build
dotnet build --configuration Release

# Run tests
dotnet test

# Pack (create NuGet package)
dotnet pack Services/Services.csproj --configuration Release
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Changelog

### 1.0.0
- Initial release
- Factory pattern for menu creation
- Fluent API with extension methods
- Support for vertical and horizontal layouts
- Three menu types (Main, Settings, Help)
- Comprehensive XML documentation

## Support

- ?? Report issues on [GitHub Issues](https://github.com/NordinsProjekt/UtilityToolBox/issues)
- ?? Read the [documentation](https://github.com/NordinsProjekt/UtilityToolBox)

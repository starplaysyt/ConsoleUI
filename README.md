# ConsoleUI

![Status](https://img.shields.io/badge/status-WIP-yellow)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20macOS-blue)
![DotNet](https://img.shields.io/badge/.NET-9.0-purple)
![License](https://img.shields.io/badge/license-MIT%20with%20Attribution-green)

**ConsoleUI** is a library that provides a complete environment for building user interfaces directly in the console.  
It includes rendering tools, window management, an input/navigation system, and a growing set of UI controls.

## Features

- Build interactive console applications with structured UI.
- Navigation between elements using arrow keys and selection with Enter.
- Full control over rendering, positioning and sizing of elements.
- Custom window lifecycle managed through `ConsoleWindow`.
- Initial set of UI controls:
  - `Label`
  - `TextBox`
  - and many more planned (panels, buttons, grids, containers).

## Architecture

ConsoleUI follows a lightweight View-based approach.  
Every window inherits from `ConsoleWindow`, and UI elements are manually registered and configured.

Controls support directional navigation (left/right/up/down) and can be positioned freely by specifying coordinates and size.

This design keeps interfaces predictable, explicit, and easy to reason about.

## Example Window Structure

```csharp
public class Window1 : ConsoleWindow
{
    Label label1 = new Label();
    Label label2 = new Label();
    TextBox textBox1 = new TextBox();

    public Window1()
    {
        InitializeComponent();

        RegisterElement(label1);
        RegisterElement(label2);
        RegisterElement(textBox1);

        SelectedElement = textBox1;
    }

    public void InitializeComponent()
    {
        label1.LocationX = 10;
        label1.LocationY = 10;
        label1.SizeX = 10;
        label1.SizeY = 10;
        label1.Text = "testText";

        label2.LocationX = 5;
        label2.LocationY = 5;
        label2.SizeX = 10;
        label2.SizeY = 10;
        label2.Text = "testText2";

        textBox1.LocationX = 5;
        textBox1.LocationY = 0;
        textBox1.SizeX = 10;
        textBox1.SizeY = 10;
        textBox1.Text = "test";

        label1.LeftElement = label2;
        label2.RightElement = label1;
        label2.TopElement = textBox1;
        textBox1.BottomElement = label2;
    }
}
```

## Supported Platforms

- .NET 9

- Windows

- macOS

ConsoleUI is fully cross-platform and works in the default system console without external dependencies.

## Project Status

WIP (Work in progress)
The library is actively being developed, and the API may change.

## License

ConsoleUI is distributed under the following license:

MIT License with Attribution Requirement:
```
Copyright (c) 2025 starplaysyt
https://github.com/starplaysyt/ConsoleUI

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, subject to the following conditions:

1. Attribution is required.
   Any redistributions of this software, in source or binary forms, must
   include a prominent attribution to the original author and repository URL
   (for example, in documentation, “About” dialogs, or credits).

2. The above copyright notice and this permission notice shall be included in
   all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```

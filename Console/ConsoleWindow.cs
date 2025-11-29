using System.Diagnostics;
using System.Drawing;
using ConsoleUI.Interfaces;

namespace ConsoleUI.Console;

public class ConsoleWindow : IWindow
{
    public bool IsRunning { get; set; } = true;
    
    public Size Size => new(System.Console.WindowWidth, System.Console.WindowHeight);

    public ConsoleRenderer Renderer = new ConsoleRenderer();
    
    private List<UIElement> _elements = new List<UIElement>();

    public UIElement? SelectedElement { get; set; } = null;

    public ConsoleWindow()
    {
        
    }

    public void RegisterElement(UIElement element)
    {
        _elements.Add(element);
        element.Owner = this;
    }

    public void Run()
    {
        while (IsRunning)
        {
            foreach (var element in _elements)
            {
                element.Draw();
                Renderer.ResetColor();
            }
            Renderer.WriteCharAt(0, 0,'\0');

            if (System.Console.KeyAvailable)
            {
                var key = System.Console.ReadKey(true);

                //TODO: Refactor that to one setting switch(like setting a linked variable to SelectedElement.<Direction>Element. Should work pretty fine
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (SelectedElement?.LeftElement != null)
                        {
                            SelectedElement.IsSelected = false;
                            SelectedElement = SelectedElement.LeftElement;
                            SelectedElement.IsSelected = true;
                            
                            Debug.Print($"Selected changed to {SelectedElement.Name}");
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (SelectedElement?.RightElement != null)
                        {
                            SelectedElement.IsSelected = false;
                            SelectedElement = SelectedElement.RightElement;
                            SelectedElement.IsSelected = true;
                            Debug.Print($"Selected changed to {SelectedElement.Name}");
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (SelectedElement?.TopElement != null)
                        {
                            SelectedElement.IsSelected = false;
                            SelectedElement = SelectedElement.TopElement;
                            SelectedElement.IsSelected = true;
                            Debug.Print($"Selected changed to {SelectedElement.Name}");
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (SelectedElement?.BottomElement != null)
                        {
                            SelectedElement.IsSelected = false;
                            SelectedElement = SelectedElement.BottomElement;
                            SelectedElement.IsSelected = true;
                            Debug.Print($"Selected changed to {SelectedElement.Name}");
                        }
                        break;
                    default:
                        SelectedElement?.Update(key);
                        break;
                }
            }
            
            
            Thread.Sleep(30);
        }
    }
}
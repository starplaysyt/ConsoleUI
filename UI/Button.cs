using System.Diagnostics;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UI;

public class Button : UIElement
{
    public string Text { get; set; } = "";
    
    public override void Draw()
    {
        if (IsSelected)
        {
            if (Foreground is ConsoleColor.Black)
                Owner.Renderer.ResetColor();
            else 
                Owner.Renderer.SetBgColor(Foreground);
            Owner?.Renderer.SetFgColor(Background);
        }
        else
        {
            if (Background is ConsoleColor.Black)
                Owner.Renderer.ResetColor();
            else
                Owner.Renderer.SetBgColor(Background);
            Owner?.Renderer.SetFgColor(Foreground);
        }
        
        Owner?.Renderer.WriteFixedStringAt(LocationX, LocationY, Text, SizeX, ' ');
    }

    public override void Update(ConsoleKeyInfo keyInfo)
    {
        Debug.Print($"Update called on {Name}");
    }
    
    public Button() : base()
    {
        IsSelectable = true;
    }
    
    public Button(string name) : base(name)
    {
        
    }
}
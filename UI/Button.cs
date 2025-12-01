using System.Diagnostics;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UI;

public class Button : UIElement
{
    public string Text { get; set; } = "";

    public event EventHandler OnClick = delegate { };
    
    public override void Draw()
    {
        var renderer = Owner?.Renderer;
        if (renderer is null) return;
        
        if (IsSelected)
        {
            if (Foreground is ConsoleColor.Black)
                renderer.ResetColor();
            else 
                renderer.SetBgColor(Foreground);
            renderer.SetFgColor(Background);
        }
        else
        {
            if (Background is ConsoleColor.Black)
                renderer.ResetColor();
            else
                renderer.SetBgColor(Background);
            renderer.SetFgColor(Foreground);
        }
        
        Owner?.Renderer.WriteFixedStringAt(LocationX, LocationY, Text, SizeX, ' ');
    }

    public override bool Update(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key is ConsoleKey.Enter)
            OnClick(this, EventArgs.Empty);
        
        return false;
    }
    
    public Button() : base()
    {
        IsSelectable = true;
    }
    
    public Button(string name) : base(name)
    {
        
    }
}
using System.Diagnostics;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UI;

public class Button : UIElement
{
    public string Text { get; set; } = "";

    public event EventHandler OnClick = delegate { };
    
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
        if (keyInfo.Key is ConsoleKey.Enter)
            OnClick(this, EventArgs.Empty);
    }
    
    public Button() : base()
    {
        IsSelectable = true;
    }
    
    public Button(string name) : base(name)
    {
        
    }
}
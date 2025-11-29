using System.Diagnostics;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UI;

public class TextBox : UIElement
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
        
        Owner?.Renderer.WriteStringAt(LocationX, LocationY, "> ");
        Owner?.Renderer.WriteFixedStringNext(Text, SizeX, ' ');
        if (Text.Length > SizeX)
        {
            Owner?.Renderer.WriteFixedStringAt(LocationX + 2 + SizeX - 3, LocationY, "...", 3, ' ');
        }
    }

    public override void Update(ConsoleKeyInfo keyInfo)
    {
        Debug.Print($"Update called on {Name}");

        if (keyInfo.Key is ConsoleKey.Backspace && Text.Length > 0)
            Text = Text[..^1];
        
        if (char.IsLetter(keyInfo.KeyChar))
            Text += keyInfo.KeyChar;
    }
    
    public TextBox() : base()
    {
        
    }
    
    public TextBox(string name) : base(name)
    {
        
    }
}
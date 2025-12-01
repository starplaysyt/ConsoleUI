using System.Diagnostics;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UI;

public class TextBox : UIElement
{
    public string Text { get; set; } = "";
    
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
            
            renderer.WriteStringAt(LocationX, LocationY, "> ");
            renderer.WriteStringNext(Text);
        }
        else
        {
            if (Background is ConsoleColor.Black)
                renderer.ResetColor();
            else
                renderer.SetBgColor(Background);
            renderer.SetFgColor(Foreground);
            
            renderer.WriteStringAt(LocationX, LocationY, "> ");
            renderer.WriteFixedStringNext(Text, SizeX, ' ');
            
            if (Text.Length > SizeX)
                renderer.WriteFixedStringAt(LocationX + 2 + SizeX - 3, LocationY, "...", 3, ' ');
        }
        
       
    }

    public override bool Update(ConsoleKeyInfo keyInfo)
    {
        Debug.Print($"Update called on {Name}");

        if (keyInfo.Key is ConsoleKey.Backspace && Text.Length > 0)
        {
            Text = Text[..^1];
            Owner?.Renderer.AskForFullCleanup();
        }


        if (char.IsLetter(keyInfo.KeyChar) || char.IsDigit(keyInfo.KeyChar))
        {
            Text += keyInfo.KeyChar;
            
            Owner?.Renderer.AskForFullCleanup();
        }

        return false;
    }
    
    public TextBox()
    {
        IsSelectable = true;
    }
    
    public TextBox(string name) : base(name)
    {
        
    }
}
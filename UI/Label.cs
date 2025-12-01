using System.Diagnostics;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UI;

public class Label : UIElement
{
    public string Text { get; set; } = "";
    
    public override void Draw()
    {
        Owner?.Renderer.WriteFixedStringAt(LocationX, LocationY, Text, SizeX, ' ');
    }

    public override bool Update(ConsoleKeyInfo keyInfo)
    {
        Debug.Print($"Update called on {Name}");
        return false;
    }
    
    public Label() : base()
    {
        IsSelectable = false;
    }
    
    public Label(string name) : base(name)
    {
        
    }
}
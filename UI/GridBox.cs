using ConsoleUI.Interfaces;

namespace ConsoleUI.UI;

public class GridBox : UIElement
{
    public override void Draw()
    {
        var renderer = Owner?.Renderer;
        if (renderer is null) return;
        
        
    }

    public override void Update(ConsoleKeyInfo keyInfo)
    {
        
    }
}
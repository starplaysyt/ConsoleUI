using ConsoleUI.Interfaces;
using ConsoleUI.Services;

namespace ConsoleUI.UI;

//WIP
public class GridBox : UIElement
{
    public UIElement?[,] Elements;

    public int ElementWidth { get; private set; }
    public int ElementHeight { get; private set; }
    
    public GridBox(int elementWidth, int elementHeight) : base(UniqueIdGiverService.Instance.GetUniqueId<GridBox>())
    {
        ElementWidth = elementWidth;
        ElementHeight = elementHeight;
        
        Elements = new UIElement[ElementWidth, ElementHeight];
    }

    public override void Draw()
    {
        var provider = ConfigurationProviderService.Instance;
        var renderer = Owner?.Renderer;
        
        if (renderer is null) return;
    }

    public void AddElement(int columnPosition, int rowPosition, UIElement element)
    {
        Elements[columnPosition, rowPosition] = element;
        
        if (columnPosition is 0) element.LeftElement = LeftElement;
        if (columnPosition == ElementWidth) element.RightElement = RightElement;
        if (rowPosition is 0) element.TopElement = TopElement;
        if (rowPosition == ElementHeight) element.BottomElement = BottomElement;
        
        Owner?.RegisterElement(element);
    }

    public override bool Update(ConsoleKeyInfo keyInfo)
    {
        return false;
    }
}
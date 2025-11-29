using ConsoleUI.Console;
using ConsoleUI.Services;

namespace ConsoleUI.Interfaces;

public abstract class UIElement
{
    private bool _isSelected = false;
    private UIElement? _topElement;
    private UIElement? _rightElement;
    private UIElement? _leftElement;
    private UIElement? _bottomElement;

    public bool IsSelectable { get; protected internal set; }

    public bool IsSelected
    {
        get => _isSelected;
        internal set
        {
            _isSelected = value;
            OnSelectedChanged(this, EventArgs.Empty);
        }
    }

    public string Name { get; private set; }

    public int LocationX { get; set; } = 0;
    public int LocationY { get; set; } = 0;
    
    public int SizeX { get; set; } = 0;
    public int SizeY { get; set; } = 0;

    public ConsoleColor Background { get; set; } = ConsoleColor.Black;
    public ConsoleColor Foreground { get; set; } = ConsoleColor.White;
    
    public ConsoleWindow? Owner { get; set; }


    public virtual UIElement? TopElement
    {
        get => _topElement;
        set
        {
            if (value is null || (IsSelectable && value.IsSelectable)) _topElement = value;
        } 
    }

    public virtual UIElement? RightElement
    {
        get => _rightElement;
        set
        {
            if (value is null || (IsSelectable && value.IsSelectable)) _rightElement = value;
        }
    }

    public virtual UIElement? LeftElement
    {
        get => _leftElement;
        set
        {
            if (value is null || (IsSelectable && value.IsSelectable)) _leftElement = value;
        }
    }

    public virtual UIElement? BottomElement
    {
        get => _bottomElement;
        set
        {
            if (value is null || (IsSelectable && value.IsSelectable)) _bottomElement = value;
        }
    }

    public event EventHandler OnSelectedChanged = delegate { };

    public event EventHandler OnUpdate = delegate { };
    
    protected UIElement(string name)
    {
        Name = name;
    }

    protected UIElement() : this(UniqueIdGiverService.Instance.GetUniqueId<UIElement>())
    {
        
    }
    
    public abstract void Draw();

    public abstract void Update(ConsoleKeyInfo keyInfo);
}
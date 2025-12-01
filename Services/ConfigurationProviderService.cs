using ConsoleUI.Interfaces;

namespace ConsoleUI.Services;

public class ConfigurationProviderService : IService, ISelfReferenced<ConfigurationProviderService>
{
    public static readonly ConfigurationProviderService Instance = new();
    
    public string ServiceIdentifier => nameof(ConfigurationProviderService);

    public char CornerTopLeft = '╔';
    public char CornerTopRight = '╗';
    public char CornerBottomLeft = '╚';
    public char CornerBottomRight = '╝';
    public char Horizontal = '═';
    public char Vertical = '║';
    public char IntersectionTop = '╩';
    public char IntersectionBottom = '╦';
    public char IntersectionLeft = '╣';
    public char IntersectionRight = '╠';
    public char IntersectionAll = '╬';

    public char Empty = ' ';

    public char ShadedBlock = '▒';
    public char ShadedBlock2 = '░';
    
    public ConsoleColor BackgroundColor = ConsoleColor.Black;
    public ConsoleColor ForegroundColor = ConsoleColor.White;
    
    public ConsoleColor SelectionBackgroundColor = ConsoleColor.White;
    public ConsoleColor SelectionForegroundColor = ConsoleColor.Black;
    
    public ConfigurationProviderService()
    {
        
    }
}
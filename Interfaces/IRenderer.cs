namespace ConsoleUI.Interfaces;

public interface IRenderer
{
    public void WriteCharAt(int x, int y, char character);
    
    public void WriteCharNext(char character);
    
    public void WriteFixedStringAt(int x, int y, string str, int width, char empty);
    
    public void WriteFixedStringNext(string str, int width, char empty);
    

}
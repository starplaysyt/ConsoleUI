namespace ConsoleUI.Interfaces;

public interface IRenderer
{
    public void AskForFullCleanup();
    public void ClearWindow();
    public void WriteCharAt(int x, int y, char character);
    public void WriteCharNext(char character);
    public void WriteFixedStringAt(int x, int y, string str, int width, char empty);
    public void WriteFixedStringNext(string str, int width, char empty);
    public void WriteStringAt(int x, int y, string str);
    public void WriteStringNext(string str);
    public void WriteChars(int locationX, int locationY, char character, int count);
    public void SetBgColor(ConsoleColor color);
    public void SetFgColor(ConsoleColor color);
    public void ResetColor();
}
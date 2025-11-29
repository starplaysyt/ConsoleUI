using System.Runtime.CompilerServices;
using ConsoleUI.Interfaces;

namespace ConsoleUI.Console;

public class ConsoleRenderer : IRenderer
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteCharAt(int x, int y, char character)
    {
        System.Console.SetCursorPosition(x, y);
        WriteCharNext(character);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteCharNext(char character) => System.Console.Write(character);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteFixedStringAt(int x, int y, string str, int width, char empty)
    {
        System.Console.SetCursorPosition(x, y);
        WriteFixedStringNext(str, width, empty);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteFixedStringNext(string str, int width, char empty)
    {
        for (var i = 0; i < Math.Min(str.Length, width); i++)
            System.Console.Write(str[i]);

        for (var i = str.Length; i < width; i++)
            System.Console.Write(empty);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteStringAt(int x, int y, string str)
    {
        System.Console.SetCursorPosition(x, y);
        WriteStringNext(str);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteStringNext(string str) => System.Console.Write(str);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetBgColor(ConsoleColor color) => System.Console.BackgroundColor = color;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetFgColor(ConsoleColor color) => System.Console.ForegroundColor = color;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ResetColor() => System.Console.ResetColor();
}
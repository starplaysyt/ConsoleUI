using System.Diagnostics;
using System.Runtime.CompilerServices;
using ConsoleUI.Interfaces;
using ConsoleUI.Services;

namespace ConsoleUI.Wrappers;

public class ConsoleRenderer : IRenderer
{
    private bool _needFullCleanup;

    public void AskForFullCleanup() => _needFullCleanup = true;
    
    public void ClearWindow()
    {
        if (!_needFullCleanup) return;

        var backgroundChar = ConfigurationProviderService.Instance.Empty;
        
        for (int i = 0; i < Console.BufferHeight; i++)
        {
            WriteChars(0, i, backgroundChar, System.Console.BufferWidth);
        }
        
        _needFullCleanup = false;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteCharAt(int x, int y, char character)
    {
        Console.SetCursorPosition(x, y); 
        WriteCharNext(character);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteCharNext(char character) => System.Console.Write(character);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteFixedStringAt(int x, int y, string str, int width, char empty)
    {
        Console.SetCursorPosition(x, y);
        WriteFixedStringNext(str, width, empty);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteFixedStringNext(string str, int width, char empty)
    {
        for (var i = 0; i < Math.Min(str.Length, width); i++)
            Console.Write(str[i]);

        for (var i = str.Length; i < width; i++)
            Console.Write(empty);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteStringAt(int x, int y, string str)
    {
        Console.SetCursorPosition(x, y);
        WriteStringNext(str);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteStringNext(string str) => Console.Write(str);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteChars(int locationX, int locationY, char character, int count)
    {
        Console.SetCursorPosition(locationX, locationY);
        for (var i = 0; i < count; i++)
        {
            Console.Write(character);
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetBgColor(ConsoleColor color) => Console.BackgroundColor = color;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetFgColor(ConsoleColor color) => Console.ForegroundColor = color;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ResetColor() => Console.ResetColor();
}
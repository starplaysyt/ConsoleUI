using ConsoleUI.UI;

namespace ConsoleUI.Interfaces;

public interface ISelfReferenced<T> where T : new()
{
    public static readonly T Instance = new T();
}
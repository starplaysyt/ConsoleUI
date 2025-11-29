using ConsoleUI.Interfaces;

namespace ConsoleUI.Services;

public class UniqueIdGiverService : IService, ISelfReferenced<UniqueIdGiverService>
{
    public static readonly UniqueIdGiverService Instance = new();
    
    public string ServiceIdentifier => nameof(UniqueIdGiverService);

    private Dictionary<string, int> _ids = new();
    
    public string GetUniqueId<T>()
    {
        var name = typeof(T).Name;
        
        if (!_ids.TryGetValue(name, out var id))
            _ids[name] = 0;
        
        return name + ++_ids[typeof(T).Name];
    }
}
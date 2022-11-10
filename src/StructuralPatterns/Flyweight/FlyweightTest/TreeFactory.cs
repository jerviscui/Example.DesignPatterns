using System.Diagnostics;

namespace FlyweightTest;

public class TreeFactory
{
    private readonly Dictionary<(string name, int size, string texture), TreeType> _treeTypes = new();

    public TreeType GeTreeType(string name, int size, string texture)
    {
        var key = (name, size, texture);

        if (_treeTypes.TryGetValue(key, out var value))
        {
            return value;
        }

        value = new TreeType(name, size, texture);
        if (_treeTypes.TryAdd(key, value))
        {
            return value;
        }

        value = _treeTypes.GetValueOrDefault(key);

        Debug.Assert(value != null, "must be not null");

        return value;
    }
}

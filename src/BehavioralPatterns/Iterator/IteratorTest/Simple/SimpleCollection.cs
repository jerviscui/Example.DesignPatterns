using System.Collections;

namespace IteratorTest;

public class SimpleCollection : IEnumerable<int>
{
    /// <inheritdoc />
    public IEnumerator<int> GetEnumerator() => new SimpleIterator(this);

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private readonly int[] _data = new int[10];

    private int _index;

    public void Add(int value)
    {
        _data[_index++] = value;
    }

    internal int InternalLength => _data.Length;

    internal int GetData(int index) => _data[index];
}

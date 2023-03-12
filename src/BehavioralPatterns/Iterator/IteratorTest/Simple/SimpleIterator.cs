using System.Collections;

namespace IteratorTest;

internal class SimpleIterator : IEnumerator<int>
{
    private readonly SimpleCollection _collection;

    private int _index;

    public SimpleIterator(SimpleCollection collection)
    {
        _collection = collection;
        _index = -1;
    }

    /// <inheritdoc />
    public bool MoveNext()
    {
        _index++;
        if (_index < _collection.InternalLength)
        {
            return true;
        }

        _index = _collection.InternalLength;
        return false;
    }

    /// <inheritdoc />
    public void Reset() => _index = -1;

    /// <inheritdoc />
    public int Current => _collection.GetData(_index);

    /// <inheritdoc />
    object IEnumerator.Current => Current;

    /// <inheritdoc />
    public void Dispose()
    {
    }
}

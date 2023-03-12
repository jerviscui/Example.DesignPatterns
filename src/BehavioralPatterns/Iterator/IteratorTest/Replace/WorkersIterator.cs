namespace IteratorTest;

internal class WorkersIterator : IProfileIterator
{
    private readonly Profile[] _array;

    public WorkersIterator(Profile[] array) => _array = array;

    private int _index;

    /// <inheritdoc />
    public bool HasNext()
    {
        for (var i = _index; i < _array.Length; i++)
        {
            if (_array[i].Type == "Workers")
            {
                _index = i;
                return true;
            }
        }

        return false;
    }

    /// <inheritdoc />
    public Profile GetNext()
    {
        var profile = _array[_index];
        _index++;
        return profile;
    }
}

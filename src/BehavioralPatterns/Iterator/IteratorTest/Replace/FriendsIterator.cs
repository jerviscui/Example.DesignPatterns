namespace IteratorTest;

internal class FriendsIterator : IProfileIterator
{
    private readonly Profile[] _array;

    public FriendsIterator(Profile[] array) => _array = array;

    private int _index;

    /// <inheritdoc />
    public bool HasNext()
    {
        for (var i = _index; i < _array.Length; i++)
        {
            if (_array[i].Type == "Friends")
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

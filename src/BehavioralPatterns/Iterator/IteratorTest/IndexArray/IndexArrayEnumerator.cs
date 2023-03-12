using System.Collections;

namespace IteratorTest;

internal class IndexArrayEnumerator<T> : IEnumerator<T>
{
    private readonly List<Container<T>> _list;

    public IndexArrayEnumerator(List<Container<T>> list, DateTime time)
    {
        _list = list;
        _index = -1;
        _start = 0;
        _time = time;
    }

    private int _start;

    private int _index;

    private readonly DateTime _time;

    /// <inheritdoc />
    public bool MoveNext()
    {
        var index = Math.Max(_index + 1, _start);

        while (index < _list.Count)
        {
            var data = _list[index];

            if (data.DeleteTime.HasValue && data.DeleteTime < _time)
            {
                index++;
                continue;
            }
            if (data.AddTime > _time)
            {
                index++;
                continue;
            }

            _index = index;
            if (_start == 0)
            {
                _start = _index;
            }

            return true;
        }

        _index = _list.Count;

        return false;
    }

    /// <inheritdoc />
    public void Reset()
    {
        _index = -1;
    }

    /// <inheritdoc />
    public T Current => _list[_index].Data;

    /// <inheritdoc />
    object IEnumerator.Current => Current;

    /// <inheritdoc />
    public void Dispose()
    {
    }
}

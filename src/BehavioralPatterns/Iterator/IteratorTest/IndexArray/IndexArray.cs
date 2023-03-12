using System.Collections;

namespace IteratorTest;

public class IndexArray<T> : IEnumerable<T> where T : IEquatable<T>
{
    private readonly int[] _indexes;

    private readonly List<Container<T>> _list;

    public IndexArray(int length)
    {
        _list = new List<Container<T>>();
        _indexes = new int[length];
        for (var i = 0; i < _indexes.Length; i++)
        {
            _indexes[i] = -1;
        }
    }

    public void Add(int index, T data)
    {
        _event.Wait();

        if (_indexes[index] != -1)
        {
            Remove(_indexes[index], index);
        }

        //add
        _list.Add(new Container<T> { AddTime = DateTime.Now, Data = data });
        var i = _list.Count;
        _indexes[index] = i - 1;
    }

    private void Remove(int i, int? index = null)
    {
        _list[i].DeleteTime = DateTime.Now;
        if (index.HasValue)
        {
            _indexes[index.Value] = -1;
        }
        else
        {
            for (var i1 = 0; i1 < _indexes.Length; i1++)
            {
                if (_indexes[i1] == i)
                {
                    _indexes[i1] = -1;
                }
            }
        }
    }

    public void Remove(T data)
    {
        _event.Wait();

        for (var i = 0; i < _list.Count; i++)
        {
            if (_list[i].Data.Equals(data))
            {
                Remove(i);
            }
        }
    }

    public T? Get(int index)
    {
        _event.Wait();

        var i = _indexes[index];
        if (i == -1)
        {
            return default;
        }

        if (_list[i].DeleteTime is not null)
        {
            throw new NotImplementedException();
        }

        return _list[i].Data;
    }

    #region IEnumerable

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        _event.Wait();

        var time = DateTime.Now;
        var enumetor = new IndexArrayEnumerator<T>(_list, time);
        _enumerators.Add((new WeakReference<IndexArrayEnumerator<T>>(enumetor), time));

        return enumetor;
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private readonly List<(WeakReference<IndexArrayEnumerator<T>> weak, DateTime time)> _enumerators = new();

    #endregion

    private readonly ManualResetEventSlim _event = new(true);

    internal void Clear()
    {
        DateTime? time = null;
        for (var i = _enumerators.Count - 1; i >= 0; i--)
        {
            if (!_enumerators[i].weak.TryGetTarget(out _))
            {
                _enumerators.RemoveAt(i);
            }
            else
            {
                if (time is null || time > _enumerators[i].time)
                {
                    time = _enumerators[i].time;
                }
            }
        }

        _event.Reset();

        for (var i = _list.Count - 1; i >= 0; i--)
        {
            if (_list[i].DeleteTime.HasValue && (time is null || _list[i].DeleteTime < time))
            {
                _list.RemoveAt(i);
                for (var i1 = 0; i1 < _indexes.Length; i1++)
                {
                    if (_indexes[i1] > i)
                    {
                        _indexes[i1]--;
                    }
                }
            }
        }

        _event.Set();
    }

    internal int Length => _list.Count;
}

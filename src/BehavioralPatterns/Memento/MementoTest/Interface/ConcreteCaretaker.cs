using System.Diagnostics;

namespace MementoTest;

internal class ConcreteCaretaker
{
    private readonly Stack<ISnapshot> _snapshots;

    public ConcreteCaretaker()
    {
        _snapshots = new Stack<ISnapshot>();
    }

    public void Push(ISnapshot snapshot)
    {
        Debug.WriteLine(snapshot.GetSnapshotCreationTime());
        _snapshots.Push(snapshot);
    }

    public ISnapshot? Pop()
    {
        return _snapshots.TryPop(out var pop) ? pop : default;
    }
}

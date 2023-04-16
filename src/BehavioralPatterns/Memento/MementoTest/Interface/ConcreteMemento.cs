namespace MementoTest;

internal class ConcreteMemento : ISnapshot
{
    public ConcreteMemento(string text, string status)
    {
        Text = text;
        Status = status;

        _creationTime = DateTime.Now;
    }

    public readonly string Text;

    public readonly string Status;

    private readonly DateTime _creationTime;

    /// <inheritdoc />
    public DateTime GetSnapshotCreationTime() => _creationTime;
}

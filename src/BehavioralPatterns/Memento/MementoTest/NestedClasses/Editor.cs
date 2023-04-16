namespace MementoTest;

internal class Editor
{
    public Editor(string text)
    {
        Text = text;
        _status = text;
    }

    public string Text { get; set; }

    private string _status;

    public ISnapshot CreateSnapshot() => new Snapshot(this);

    public void Restore(ISnapshot snapshot)
    {
        var s = (Snapshot)snapshot;
        Text = s.Text;
        _status = s.Status;
    }

    private class Snapshot : ISnapshot
    {
        public Snapshot(Editor editor)
        {
            Text = editor.Text;
            Status = editor._status;

            _creationTime = DateTime.Now;
        }

        public readonly string Text;

        public readonly string Status;

        private readonly DateTime _creationTime;

        /// <inheritdoc />
        public DateTime GetSnapshotCreationTime() => _creationTime;
    }
}

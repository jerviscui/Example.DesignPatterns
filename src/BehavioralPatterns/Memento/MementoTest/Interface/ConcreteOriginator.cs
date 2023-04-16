namespace MementoTest;

internal class ConcreteOriginator
{
    public ConcreteOriginator(string text)
    {
        Text = text;
        _status = text;
    }

    public string Text { get; set; }

    private string _status;

    public ConcreteMemento CreateSnapshot() => new(Text, _status);

    public void Restore(ConcreteMemento snapshot)
    {
        Text = snapshot.Text;
        _status = snapshot.Status;
    }
}

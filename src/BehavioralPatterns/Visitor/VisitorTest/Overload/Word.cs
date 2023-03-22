namespace VisitorTest;

internal class Word : Files
{
    /// <inheritdoc />
    public Word(string path) : base(path)
    {
    }

    /// <inheritdoc />
    public override void Accept(IVistor vistor)
    {
        vistor.Visit(this);
    }
}

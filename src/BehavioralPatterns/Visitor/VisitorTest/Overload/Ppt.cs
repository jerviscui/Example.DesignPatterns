namespace VisitorTest;

internal class Ppt : Files
{
    /// <inheritdoc />
    public Ppt(string path) : base(path)
    {
    }

    /// <inheritdoc />
    public override void Accept(IVistor vistor)
    {
        vistor.Visit(this);
    }
}

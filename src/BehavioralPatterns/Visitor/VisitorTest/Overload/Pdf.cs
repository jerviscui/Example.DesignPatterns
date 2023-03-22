namespace VisitorTest;

internal class Pdf : Files
{
    /// <inheritdoc />
    public Pdf(string path) : base(path)
    {
    }

    /// <inheritdoc />
    public override void Accept(IVistor vistor)
    {
        vistor.Visit(this);
    }
}

namespace VisitorTest;

internal class Dot : IShape
{
    /// <inheritdoc />
    public void Accept(IVisitor visitor)
    {
        visitor.VisitDot(this);
    }
}

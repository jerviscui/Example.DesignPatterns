namespace VisitorTest;

internal class Circle : IShape
{
    /// <inheritdoc />
    public void Accept(IVisitor visitor)
    {
        visitor.VisitCircle(this);
    }
}

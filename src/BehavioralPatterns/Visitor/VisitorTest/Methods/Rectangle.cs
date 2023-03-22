namespace VisitorTest;

internal class Rectangle : IShape
{
    /// <inheritdoc />
    public void Accept(IVisitor visitor)
    {
        visitor.VisitRectangle(this);
    }
}

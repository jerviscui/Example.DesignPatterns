namespace VisitorTest;

internal interface IShape
{
    public void Accept(IVisitor visitor);
}

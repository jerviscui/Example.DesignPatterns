namespace VisitorTest;

internal interface IVisitor
{
    public void VisitDot(Dot dot);

    public void VisitCircle(Circle circle);

    public void VisitRectangle(Rectangle rectangle);
}

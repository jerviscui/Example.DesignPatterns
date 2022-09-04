namespace PrototypeTest.Derived;

public class Circle : Shape
{
    public float Radius { get; }

    /// <inheritdoc />
    public Circle(Shape shape, float radius) : base(shape) => Radius = radius;

    public Circle()
    {
        Radius = 0;
    }

    /// <inheritdoc />
    public override Circle Clone()
    {
        return new Circle(this, Radius);
    }
}

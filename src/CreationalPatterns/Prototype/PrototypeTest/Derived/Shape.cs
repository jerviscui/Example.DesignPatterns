namespace PrototypeTest.Derived;

public abstract class Shape : ICloneable<Shape>
{
    protected Shape(Shape shape)
    {
        X = shape.X;
        Y = shape.Y;
    }

    protected Shape()
    {
    }

    public int X { get; }

    public int Y { get; }

    /// <inheritdoc />
    public abstract Shape Clone();

    /// <inheritdoc />
    object ICloneable.Clone() => Clone();
}

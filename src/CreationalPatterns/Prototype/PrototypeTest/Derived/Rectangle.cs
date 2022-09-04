namespace PrototypeTest.Derived;

public class Rectangle : Shape
{
    /// <inheritdoc />
    public Rectangle(Shape shape, int width, int height) : base(shape)
    {
        Width = width;
        Height = height;
    }

    public Rectangle()
    {
        Width = 0;
        Height = 0;
    }

    public int Width { get; }

    public int Height { get; }

    /// <inheritdoc />
    public override Rectangle Clone()
    {
        return new Rectangle(this, Width, Height);
    }
}

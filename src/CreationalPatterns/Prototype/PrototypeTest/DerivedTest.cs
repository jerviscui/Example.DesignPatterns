using PrototypeTest.Derived;

namespace PrototypeTest;

public class DerivedTest
{
    [Fact]
    public void Clone_Test()
    {
        var circle = new Circle();
        var shapes = new Shape[] { circle, circle.Clone(), new Rectangle() };

        foreach (var shape in shapes)
        {
            shape.Clone();
        }
    }
}

namespace FactoryTest.AbstractFactory;

public abstract class Chair : IStyle
{
    protected Chair(Style style) => Style = style;

    /// <inheritdoc />
    public Style Style { get; }
}

public class ModernChair : Chair
{
    /// <inheritdoc />
    public ModernChair() : base(Style.Modern)
    {
    }
}

public class VictorianChair : Chair
{
    /// <inheritdoc />
    public VictorianChair() : base(Style.Victorian)
    {
    }
}

public class ArtDecoChair : Chair
{
    /// <inheritdoc />
    public ArtDecoChair() : base(Style.ArtDeco)
    {
    }
}

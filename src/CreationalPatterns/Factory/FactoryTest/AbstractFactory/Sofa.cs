namespace FactoryTest.AbstractFactory;

public abstract class Sofa : IStyle
{
    protected Sofa(Style style) => Style = style;

    /// <inheritdoc />
    public Style Style { get; }
}

public class ModernSofa : Sofa
{
    /// <inheritdoc />
    public ModernSofa() : base(Style.Modern)
    {
    }
}

public class VictorianSofa : Sofa
{
    /// <inheritdoc />
    public VictorianSofa() : base(Style.Victorian)
    {
    }
}

public class ArtDecoSofa : Sofa
{
    /// <inheritdoc />
    public ArtDecoSofa() : base(Style.ArtDeco)
    {
    }
}

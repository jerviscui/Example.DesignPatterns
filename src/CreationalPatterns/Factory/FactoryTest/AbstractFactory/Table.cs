namespace FactoryTest.AbstractFactory;

public abstract class Table : IStyle
{
    protected Table(Style style) => Style = style;

    /// <inheritdoc />
    public Style Style { get; }
}

public class ModernTable : Table
{
    /// <inheritdoc />
    public ModernTable() : base(Style.Modern)
    {
    }
}

public class VictorianTable : Table
{
    /// <inheritdoc />
    public VictorianTable() : base(Style.Victorian)
    {
    }
}

public class ArtDecoTable : Table
{
    /// <inheritdoc />
    public ArtDecoTable() : base(Style.ArtDeco)
    {
    }
}

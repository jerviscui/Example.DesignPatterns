namespace FactoryTest.AbstractFactory;

public abstract class ProductFactory
{
    /// <summary>
    /// Creates the sofa.
    /// </summary>
    public abstract Sofa CreateSofa();

    /// <summary>
    /// Creates the Chairacter.
    /// </summary>
    public abstract Chair CreateChair();

    /// <summary>
    /// Creates the table.
    /// </summary>
    public abstract Table CreateTable();
}

public class ModernProductFactory : ProductFactory
{
    /// <inheritdoc />
    public override Sofa CreateSofa() => new ModernSofa();

    /// <inheritdoc />
    public override Chair CreateChair() => new ModernChair();

    /// <inheritdoc />
    public override Table CreateTable() => new ModernTable();
}

public class VictorianProductFactory : ProductFactory
{
    /// <inheritdoc />
    public override Sofa CreateSofa() => new VictorianSofa();

    /// <inheritdoc />
    public override Chair CreateChair() => new VictorianChair();

    /// <inheritdoc />
    public override Table CreateTable() => new VictorianTable();
}

public class ArtDecoProductFactory : ProductFactory
{
    /// <inheritdoc />
    public override Sofa CreateSofa() => new ArtDecoSofa();

    /// <inheritdoc />
    public override Chair CreateChair() => new ArtDecoChair();

    /// <inheritdoc />
    public override Table CreateTable() => new ArtDecoTable();
}

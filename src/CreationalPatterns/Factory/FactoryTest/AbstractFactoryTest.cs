using FactoryTest.AbstractFactory;
using Shouldly;
using Xunit;

namespace FactoryTest;

public class AbstractFactoryTest
{
    [Fact]
    public void ModernProductFactory_Test()
    {
        ProductFactory factory = new ModernProductFactory();

        factory.CreateChair().Style.ShouldBe(Style.Modern);
        factory.CreateSofa().Style.ShouldBe(Style.Modern);
        factory.CreateTable().Style.ShouldBe(Style.Modern);
    }

    [Fact]
    public void ArtDecoProductFactory_Test()
    {
        ProductFactory factory = new ArtDecoProductFactory();

        factory.CreateChair().Style.ShouldBe(Style.ArtDeco);
        factory.CreateSofa().Style.ShouldBe(Style.ArtDeco);
        factory.CreateTable().Style.ShouldBe(Style.ArtDeco);
    }

    [Fact]
    public void VictorianProductFactory_Test()
    {
        ProductFactory factory = new VictorianProductFactory();

        factory.CreateChair().Style.ShouldBe(Style.Victorian);
        factory.CreateSofa().Style.ShouldBe(Style.Victorian);
        factory.CreateTable().Style.ShouldBe(Style.Victorian);
    }
}

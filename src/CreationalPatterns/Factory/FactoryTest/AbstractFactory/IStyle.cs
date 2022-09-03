namespace FactoryTest.AbstractFactory;

public interface IStyle
{
    public Style Style { get; }
}

public enum Style
{
    None,

    Modern,

    Victorian,

    ArtDeco
}

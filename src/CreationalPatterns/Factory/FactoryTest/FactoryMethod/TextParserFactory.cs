using FactoryTest.SimpleFactory;

namespace FactoryTest.FactoryMethod;

public class TextParserFactory : IParserFactory
{
    /// <inheritdoc />
    public IParser CreateParser() => new TxtParser();
}

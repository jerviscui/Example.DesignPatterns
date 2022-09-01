using FactoryTest.SimpleFactory;

namespace FactoryTest.FactoryMethod;

public class JsonParserFactory : IParserFactory
{
    /// <inheritdoc />
    public IParser CreateParser() => new JsonParser();
}

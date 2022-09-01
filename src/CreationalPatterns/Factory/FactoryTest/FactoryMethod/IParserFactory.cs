using FactoryTest.SimpleFactory;

namespace FactoryTest.FactoryMethod;

public interface IParserFactory
{
    /// <summary>
    /// Creates the parser.
    /// </summary>
    public IParser CreateParser();
}

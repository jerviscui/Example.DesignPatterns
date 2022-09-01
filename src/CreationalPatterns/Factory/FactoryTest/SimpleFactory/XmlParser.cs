namespace FactoryTest.SimpleFactory;

public class XmlParser : IParser
{
    /// <inheritdoc />
    public string Parse(string input) => "xml";
}

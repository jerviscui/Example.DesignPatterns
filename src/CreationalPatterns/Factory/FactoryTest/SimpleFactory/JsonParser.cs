namespace FactoryTest.SimpleFactory;

public class JsonParser : IParser
{
    /// <inheritdoc />
    public string Parse(string input) => "json";
}

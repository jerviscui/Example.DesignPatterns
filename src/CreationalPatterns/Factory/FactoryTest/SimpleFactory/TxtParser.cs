namespace FactoryTest.SimpleFactory;

public class TxtParser : IParser
{
    /// <inheritdoc />
    public string Parse(string input) => "txt";
}

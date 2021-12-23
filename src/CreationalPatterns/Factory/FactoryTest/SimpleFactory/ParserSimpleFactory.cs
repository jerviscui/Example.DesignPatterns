namespace FactoryTest;

public class ParserSimpleFactory
{
    public static IParser CreateParser(string suffix)
    {
        return suffix switch
        {
            "txt" => new TxtParser(),
            "json" => new JsonParser(),
            "xml" => new XmlParser(),
            _ => throw new NotImplementedException()
        };
    }
}

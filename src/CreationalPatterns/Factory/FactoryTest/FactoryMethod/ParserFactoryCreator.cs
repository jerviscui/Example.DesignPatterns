namespace FactoryTest.FactoryMethod;

public class ParserFactoryCreator
{
    private static readonly Dictionary<string, IParserFactory> Factories = new()
    {
        { "json", new JsonParserFactory() }, { "txt", new TextParserFactory() }
    };

    public static IParserFactory GetParserFactory(string suffix)
    {
        var factory = Factories.GetValueOrDefault(suffix);

        if (factory is null)
        {
            throw new NotImplementedException();
        }

        return factory;
    }
}

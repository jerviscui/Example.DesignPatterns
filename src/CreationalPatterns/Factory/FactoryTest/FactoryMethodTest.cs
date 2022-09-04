using FactoryTest.FactoryMethod;

namespace FactoryTest;

public class FactoryMethodTest
{
    [Fact]
    public void GetParserFactory_Test()
    {
        ParserFactoryCreator.GetParserFactory("txt").CreateParser().Parse(string.Empty).ShouldBe("txt");
        ParserFactoryCreator.GetParserFactory("json").CreateParser().Parse(string.Empty).ShouldBe("json");
    }

    [Fact]
    public void GetParserFactory_NotImplementedException_Test()
    {
        ShouldThrowExtensions.ShouldThrow<NotImplementedException>(() =>
            ParserFactoryCreator.GetParserFactory("aaa"));
    }
}

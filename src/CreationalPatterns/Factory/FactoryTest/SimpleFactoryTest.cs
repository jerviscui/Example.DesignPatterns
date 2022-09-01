using FactoryTest.SimpleFactory;
using Shouldly;
using Xunit;

namespace FactoryTest;

public class SimpleFactoryTest
{
    [Fact]
    public void CreateParser_Test()
    {
        ParserSimpleFactory.CreateParser("txt").Parse(string.Empty).ShouldBe("txt");
        ParserSimpleFactory.CreateParser("json").Parse(string.Empty).ShouldBe("json");
        ParserSimpleFactory.CreateParser("xml").Parse(string.Empty).ShouldBe("xml");
    }

    [Fact]
    public void CreateParser_NotImplementedException_Test()
    {
        ShouldThrowExtensions.ShouldThrow<NotImplementedException>(() =>
            ParserSimpleFactory.CreateParser("aaa").Parse(string.Empty));
    }
}

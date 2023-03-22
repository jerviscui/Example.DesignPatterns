namespace VisitorTest
{
    public class OverloadTests
    {
        [Theory]
        [InlineData("pdf", "ppt", "word")]
        public void Test1(params string[] args)
        {
            var list = new List<Files> { new Pdf(args[0]), new Ppt(args[1]), new Word(args[2]) };

            var visitor = new Extractor();

            for (var i = 0; i < list.Count; i++)
            {
                list[i].Accept(visitor);
                visitor.GetPath().ShouldBe(args[i]);
            }
        }
    }
}

namespace VisitorTest
{
    public class MethodsTests
    {
        [Fact]
        public void Test1()
        {
            var list = new List<IShape>();

            var visitor = new XmlExportVisitor();

            foreach (var shape in list)
            {
                shape.Accept(visitor);
            }
        }
    }
}

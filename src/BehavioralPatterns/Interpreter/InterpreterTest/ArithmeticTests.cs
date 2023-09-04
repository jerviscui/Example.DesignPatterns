namespace InterpreterTest
{
    public class ArithmeticTests
    {
        [Fact]
        public void Test()
        {
            //"8 3 2 4 - + *"

            var left = new NumberExpression(8);
            var right = new NumberExpression(3);

            var sub = new SubtractionExpression(left, right);

            var add = new AdditionExpression(sub, new NumberExpression(2));

            var result = new MulitionExpression(add, new NumberExpression(4));

            result.Interpreter().ShouldBe(28);
        }
    }
}

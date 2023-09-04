namespace InterpreterTest
{
    public class AlertRuleTests
    {
        [Fact]
        public void GreaterOnly_True_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 110 } }).ShouldBeTrue();
        }

        [Fact]
        public void GreaterOnly_False_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 100 } }).ShouldBeFalse();
        }

        [Fact]
        public void SmallerOnly_Invalid_Test()
        {
            ShouldThrowExtensions.ShouldThrow<ArgumentException>(() => new SmallerThanExpression("key1 > 100"));
        }

        [Fact]
        public void SmallerOnly_True_Test()
        {
            var rule = new AlertRuleInterpreter("key1 < 100");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 90 } }).ShouldBeTrue();
        }

        [Fact]
        public void SmallerOnly_False_Test()
        {
            var rule = new AlertRuleInterpreter("key1 < 100");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 100 } }).ShouldBeFalse();
        }

        [Fact]
        public void EqualOnly_True_Test()
        {
            var rule = new AlertRuleInterpreter("key1 == 100");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 100 } }).ShouldBeTrue();
        }

        [Fact]
        public void EqualOnly_False_Test()
        {
            var rule = new AlertRuleInterpreter("key1 == 100");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 110 } }).ShouldBeFalse();
        }

        [Fact]
        public void And_True_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100 && key2 < 50");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 110 }, { "key2", 40 } }).ShouldBeTrue();
        }

        [Fact]
        public void And_False_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100 && key2 < 50");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 110 } }).ShouldBeFalse();
        }

        [Fact]
        public void Or_True_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100 || key2 < 50");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 110 } }).ShouldBeTrue();
        }

        [Fact]
        public void Or_False_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100 || key2 < 50");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 90 }, { "key2", 50 } }).ShouldBeFalse();
        }

        [Fact]
        public void Complex_Breaker_True_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100 && key2 > 50 || key3 < 50 && key4 < 60");

            rule.Interpreter(new Dictionary<string, long> { { "key1", 110 }, { "key2", 60 } }).ShouldBeTrue();
        }

        [Fact]
        public void Complex_False_Test()
        {
            var rule = new AlertRuleInterpreter("key1 > 100 && key2 > 50 || key3 < 50 && key4 < 60");

            rule.Interpreter(new Dictionary<string, long>
            {
                { "key1", 100 }, { "key2", 50 }, { "key3", 50 }, { "key4", 60 }
            }).ShouldBeFalse();
        }

        [Fact]
        public void Complex_Breaker2_True_Test()
        {
            var rule = new AlertRuleInterpreter("key2 > 50 || key3 < 50 && key4 < 60");

            rule.Interpreter(new Dictionary<string, long> { { "key3", 40 }, { "key4", 50 } }).ShouldBeTrue();
        }
    }
}

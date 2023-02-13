namespace TemplateTest
{
    public class TemplateTests
    {
        [Fact]
        public void ConcreteClass1_Test()
        {
            var class1 = new ConcreteClass1();

            class1.TemplateMethod();

            class1.Executed.ShouldBe(40);
        }

        [Fact]
        public void ConcreteClass2_Test()
        {
            var class2 = new ConcreteClass2();

            class2.TemplateMethod();

            class2.Executed.ShouldBe(3);
        }
    }
}

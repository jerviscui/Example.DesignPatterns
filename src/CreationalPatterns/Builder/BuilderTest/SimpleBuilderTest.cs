using BuilderTest.SimpleBuilder;

namespace BuilderTest
{
    public class SimpleBuilderTest
    {
        [Fact]
        public void ConstructorArgBuilder_Build_ArgumentNullException_Test()
        {
            var builder = new ConstructorArgBuilder();
            ShouldThrowExtensions.ShouldThrow<ArgumentNullException>(() => builder.Build());
        }

        [Fact]
        public void ConstructorArgBuilder_SetIsRefWithTrue_Test()
        {
            var builder = new ConstructorArgBuilder();
            builder.SetIsRef(true);
            var constructorArg = builder.Build();

            constructorArg.Arg.ShouldBe("arg is string");
        }

        [Fact]
        public void ConstructorArgBuilder_SetIsRef_ArgumentNullException_Test()
        {
            var builder = new ConstructorArgBuilder();

            ShouldThrowExtensions.ShouldThrow<ArgumentNullException>(() => builder.SetIsRef(false));
        }

        [Fact]
        public void ConstructorArgBuilder_SetIsRefWithFalse_Test()
        {
            int arg = 10;

            var builder = new ConstructorArgBuilder();
            builder.SetType(arg.GetType());
            builder.SetArg(arg);
            builder.SetIsRef(false);
            var constructorArg = builder.Build();

            constructorArg.Arg.ShouldBe(arg);
            constructorArg.Type.ShouldBe(arg.GetType());
        }
    }
}

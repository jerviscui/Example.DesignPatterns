namespace FacadeTest
{
    public class FacadeTests
    {
        [Fact]
        public void UseFacadeClass_Test()
        {
            var facadeClass = new FacadeClass();

            facadeClass.Sale();
        }
    }
}

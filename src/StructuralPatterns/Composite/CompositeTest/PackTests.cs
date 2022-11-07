namespace CompositeTest
{
    public class PackTests
    {
        private IPack pack;

        public PackTests()
        {
            var package = new Package();
            var p_2 = new Package();
            var p_3_1 = new Package();
            var p_3_2 = new Package();

            p_3_1.AddPack(new Goods(10));
            p_3_2.AddPack(new Goods(5));

            p_2.AddPack(p_3_1);
            p_2.AddPack(p_3_2);

            package.AddPack(p_2);
            package.AddPack(new Goods(10));

            pack = package;
        }

        [Fact]
        public void CalculatePrice_Test()
        {
            pack.CalculatePrice().ShouldBe(29);
        }
    }
}

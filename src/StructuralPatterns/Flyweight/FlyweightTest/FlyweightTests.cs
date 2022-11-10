namespace FlyweightTest
{
    public class FlyweightTests
    {
        [Fact]
        public void Test1()
        {
            var forest = new Forest();

            var tree1 = forest.PlantTree("n1", 1, "texture", 1, 1);
            var tree2 = forest.PlantTree("n1", 1, "texture", 1, 2);
            var tree3 = forest.PlantTree("n2", 10, "texture", 1, 3);

            forest.Draw();

            tree1.TreeType.Equals(tree2.TreeType).ShouldBeTrue();
            tree1.TreeType.Equals(tree3.TreeType).ShouldBeFalse();
        }
    }
}

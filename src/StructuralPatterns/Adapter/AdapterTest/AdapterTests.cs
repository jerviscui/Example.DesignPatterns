namespace AdapterTest
{
    public class AdapterTests
    {
        [Fact]
        public void Fits_RoundPeg_True_Test()
        {
            var roundHole = new RoundHole(5);
            var roundPeg = new RoundPeg(5);

            roundHole.Fits(roundPeg).ShouldBeTrue();
        }

        [Fact]
        public void Fits_SquarePeg_True_Test()
        {
            var roundHole = new RoundHole(5);

            var squarePeg = new SquarePeg(3);
            var roundPeg = new SquarePegAdapter(squarePeg);

            roundHole.Fits(roundPeg).ShouldBeTrue();
        }

        [Fact]
        public void Fits_SquarePeg_False_Test()
        {
            var roundHole = new RoundHole(5);

            var squarePeg = new SquarePeg(8);
            var roundPeg = new SquarePegAdapter(squarePeg);

            roundHole.Fits(roundPeg).ShouldBeFalse();
        }
    }
}

using TestBase;

namespace StateTest
{
    public class MarioStateTests : BaseTest
    {
    }

    public enum State
    {
        Cape,

        Fire,

        Super,

        Small
    }

    internal class MarioState
    {
        public int[][] MyProperty { get; set; } =
        {
            new[] { 0, 0, -200, 0 }, new[] { 0, 0, -300, 0 }, new[] { 1, 1, 0, 100 }, new[] { 1, 1, -100, 0 }
        };
    }
}

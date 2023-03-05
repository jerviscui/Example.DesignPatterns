namespace StrategyTest
{
    public class ContextTests
    {
        [Theory]
        [InlineData(nameof(RoadStrategy))]
        [InlineData(nameof(WalkingStrategy))]
        [InlineData(nameof(PublicTransportStrategy))]
        public void CallerTests(string action)
        {
            // Arrange
            var navigator = new NavigatorContext(new Point(), new Point());

            // Act
            if (action == nameof(RoadStrategy))
            {
                navigator.SetStrategy(new RoadStrategy());
            }
            else if (action == nameof(WalkingStrategy))
            {
                navigator.SetStrategy(new WalkingStrategy());
            }
            else if (action == nameof(PublicTransportStrategy))
            {
                navigator.SetStrategy(new PublicTransportStrategy());
            }

            // Assert
            Should.Throw<NotImplementedException>(() => navigator.BuildRoute())
                .Message.ShouldBe(action);
        }
    }
}

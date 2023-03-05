namespace StrategyTest;

internal class NavigatorContext
{
    private IRouteStrategy? _routeStrategy;

    public NavigatorContext(Point pointA, Point pointB)
    {
        PointA = pointA;
        PointB = pointB;
    }

    public Point PointA { get; set; }

    public Point PointB { get; set; }

    public void SetStrategy(IRouteStrategy strategy) =>
        _routeStrategy = strategy;

    public void BuildRoute()
    {
        if (_routeStrategy is null)
        {
            throw new ArgumentNullException(nameof(_routeStrategy));
        }

        _routeStrategy.BuildRoute(PointA, PointB);
    }
}

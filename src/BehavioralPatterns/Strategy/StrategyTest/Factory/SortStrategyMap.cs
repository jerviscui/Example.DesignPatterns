namespace StrategyTest;

internal static class SortStrategyMap
{
    private static readonly long[] Sizes = { 1_000, 1_000_000, 1_000_000_000, 1_000_000_000_000 };

    private static readonly Func<ISortStrategy>[] Strategies =
    {
        () => new QuickSortStrategy(), () => new ExternalSortStrategy(), () => new ConcurrentSortStrategy(),
        () => new MapReduceSortStrategy()
    };

    //get strategy
    public static ISortStrategy GetStrategy(long size)
    {
        for (var i = 0; i < Sizes.Length; i++)
        {
            if (size < Sizes[i])
            {
                return Strategies[i]();
            }
        }

        return Strategies[^1]();
    }
}

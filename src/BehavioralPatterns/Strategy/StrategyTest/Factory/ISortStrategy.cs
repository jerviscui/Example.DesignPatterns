namespace StrategyTest;

internal interface ISortStrategy
{
    public void Sort(string path);
}

/// <summary>
/// 快速排序
/// </summary>
/// <seealso cref="StrategyTest.ISortStrategy" />
internal class QuickSortStrategy : ISortStrategy
{
    public void Sort(string path)
    {
        //读取到内存排序
        throw new NotImplementedException(nameof(QuickSortStrategy));
    }
}

/// <summary>
/// 外部排序
/// </summary>
/// <seealso cref="StrategyTest.ISortStrategy" />
internal class ExternalSortStrategy : ISortStrategy
{
    public void Sort(string path)
    {
        //没办法一次性加载文件中的所有数据到内存中，这个时候，我们就要利用外部排序算法
        throw new NotImplementedException(nameof(ExternalSortStrategy));
    }
}

/// <summary>
/// 多线程外部排序
/// </summary>
/// <seealso cref="StrategyTest.ISortStrategy" />
internal class ConcurrentSortStrategy : ISortStrategy
{
    public void Sort(string path)
    {
        //如果文件更大，利用 CPU 多核的优势，可以在外部排序的基础上加入多线程并发排序的功能
        throw new NotImplementedException(nameof(ConcurrentSortStrategy));
    }
}

/// <summary>
/// 利用MapReduce多机排序
/// </summary>
/// <seealso cref="StrategyTest.ISortStrategy" />
internal class MapReduceSortStrategy : ISortStrategy
{
    public void Sort(string path)
    {
        //如果文件非常大，可以使用真正的 MapReduce 框架，利用多机的处理能力
        throw new NotImplementedException(nameof(MapReduceSortStrategy));
    }
}

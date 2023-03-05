namespace StrategyTest;

internal class Sorter
{
    private string Path { get; set; }

    private IFileSize FileSize { get; set; }

    public Sorter(string path, IFileSize fileSize)
    {
        Path = path;
        FileSize = fileSize;
    }

    public void SortFile()
    {
        var size = FileSize.GetSize();

        var strategy = SortStrategyMap.GetStrategy(size);
        strategy.Sort(Path);
    }
}

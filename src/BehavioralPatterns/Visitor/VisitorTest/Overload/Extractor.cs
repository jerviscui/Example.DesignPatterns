namespace VisitorTest;

internal class Extractor : IVistor
{
    public string GetPath() => _path;

    private string _path = string.Empty;

    public void Visit(Pdf file)
    {
        _path = file.Path;
    }

    public void Visit(Word file)
    {
        _path = file.Path;
    }

    public void Visit(Ppt file)
    {
        _path = file.Path;
    }
}

namespace VisitorTest;

internal abstract class Files
{
    protected Files(string path) => Path = path;

    public string Path { get; set; }

    public abstract void Accept(IVistor vistor);
}

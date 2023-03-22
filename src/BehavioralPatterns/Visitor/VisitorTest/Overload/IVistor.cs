namespace VisitorTest;

internal interface IVistor
{
    public void Visit(Pdf file);

    public void Visit(Word file);

    public void Visit(Ppt file);
}

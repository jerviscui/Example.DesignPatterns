namespace IteratorTest;

public class Class1
{
    public IEnumerable<string> For()
    {
        yield return "1";
        yield return "2";
        yield return "3";
    }

    public void Do()
    {
        foreach (var s in For())
        {
        }
    }
}

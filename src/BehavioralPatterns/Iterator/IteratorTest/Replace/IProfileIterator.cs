namespace IteratorTest;

public interface IProfileIterator
{
    public bool HasNext();

    public Profile GetNext();
}

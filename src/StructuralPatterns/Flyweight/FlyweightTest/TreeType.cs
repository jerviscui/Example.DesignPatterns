namespace FlyweightTest;

public class TreeType
{
    internal TreeType(string name, int size, string texture)
    {
        Name = name;
        Size = size;
        Texture = texture;
    }

    public string Name { get; }

    public int Size { get; }

    public string Texture { get; }
}

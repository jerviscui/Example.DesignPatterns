namespace FlyweightTest;

public class Forest
{
    private readonly TreeFactory _treeFactory = new();

    public IList<Tree> Trees { get; } = new List<Tree>();

    public Tree PlantTree(string name, int size, string texture, int pointX, int pointY)
    {
        var treeType = _treeFactory.GeTreeType(name, size, texture);

        var tree = new Tree(pointX, pointY, treeType);
        Trees.Add(tree);

        return tree;
    }

    public void Draw()
    {
        foreach (var tree in Trees)
        {
            tree.Draw();
        }
    }
}

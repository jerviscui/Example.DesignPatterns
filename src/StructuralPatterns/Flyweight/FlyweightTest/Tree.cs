namespace FlyweightTest;

public class Tree
{
    public int PointX { get; set; }

    public int PointY { get; set; }

    public TreeType TreeType { get; set; }

    public Tree(int pointX, int pointY, TreeType treeType)
    {
        PointX = pointX;
        PointY = pointY;
        TreeType = treeType;
    }

    public void Draw()
    {
        TreeType xx = null;
        //todo: get TreeType mem address
        //fixed (int* p = &xx.Size)
        //{
        //}

        var s = "";
    }
}

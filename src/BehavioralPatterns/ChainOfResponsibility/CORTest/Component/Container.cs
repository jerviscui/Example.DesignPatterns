namespace CORTest;

internal class Container : Component
{
    private readonly List<Component> _children;

    public void AddChild(Component child)
    {
        _children.Add(child);
        child.Container = this;
    }

    /// <inheritdoc />
    public Container(string? tooltipText) : base(tooltipText)
    {
        _children = new List<Component>();
    }
}

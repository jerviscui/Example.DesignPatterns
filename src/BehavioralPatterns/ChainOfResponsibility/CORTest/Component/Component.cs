namespace CORTest;

internal class Component : IComponentWithContextualHelp
{
    public Component(string? tooltipText) => TooltipText = tooltipText;

    public Container? Container;

    public string? TooltipText { get; set; }

    public virtual void ShowHelp()
    {
        if (TooltipText != null)
        {
            // Show the tooltip
        }
        else
        {
            Container?.ShowHelp();
        }
    }
}

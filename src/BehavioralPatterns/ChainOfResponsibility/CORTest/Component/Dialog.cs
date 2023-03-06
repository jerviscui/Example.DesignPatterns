namespace CORTest;

internal class Dialog : Container
{
    public string? WikiUrl { get; set; }

    public override void ShowHelp()
    {
        if (WikiUrl != null)
        {
            // Show wiki
        }
        else
        {
            base.ShowHelp();
        }
    }

    /// <inheritdoc />
    public Dialog(string? tooltipText) : base(tooltipText)
    {
    }
}

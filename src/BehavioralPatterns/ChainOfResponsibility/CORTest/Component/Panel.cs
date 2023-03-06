namespace CORTest;

internal class Panel : Container
{
    public string? ModalHelpText { get; set; }

    public override void ShowHelp()
    {
        if (ModalHelpText != null)
        {
            // Show Modal window
        }
        else
        {
            base.ShowHelp();
        }
    }

    /// <inheritdoc />
    public Panel() : base(null)
    {
    }
}

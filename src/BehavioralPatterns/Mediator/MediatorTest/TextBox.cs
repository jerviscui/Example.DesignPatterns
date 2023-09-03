internal class TextBox : Component
{
    /// <inheritdoc />
    public TextBox(IMediator dialog) : base(dialog)
    {
    }

    public string Text { get; set; }
}

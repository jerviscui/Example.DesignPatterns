internal class CheckBox : Component
{
    /// <inheritdoc />
    public CheckBox(IMediator dialog) : base(dialog)
    {
    }

    public void Check()
    {
        IsChecked = !IsChecked;

        Dialog.Notify(this, "check");
    }

    public bool IsChecked { get; private set; }
}

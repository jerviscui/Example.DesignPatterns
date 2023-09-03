internal class AuthenticationDialog : IMediator
{
    public readonly Button OkBtn;

    public readonly Button CancelBtn;

    public readonly CheckBox SaveChkBx;

    public readonly TextBox Title;

    public AuthenticationDialog()
    {
        OkBtn = new Button(this);
        CancelBtn = new Button(this);
        SaveChkBx = new CheckBox(this);
        Title = new TextBox(this);
    }

    /// <inheritdoc />
    public void Notify(object sender, string @event)
    {
        if (sender == OkBtn)
        {
            if (@event == "click")
            {
                Title.Text = SaveChkBx.IsChecked ? "OK" : "must be checked";
            }
        }

        if (sender == CancelBtn)
        {
            if (@event == "click")
            {
                Title.Text = "Cancel";
            }
        }

        if (sender == SaveChkBx)
        {
            if (@event == "check")
            {
            }
        }
    }
}

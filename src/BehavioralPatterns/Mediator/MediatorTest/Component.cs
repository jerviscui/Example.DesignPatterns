internal abstract class Component
{
    protected readonly IMediator Dialog;

    protected Component(IMediator dialog) => Dialog = dialog;

    public virtual void Click()
    {
        Dialog.Notify(this, "click");
    }

    public virtual void KeyPress()
    {
        Dialog.Notify(this, "keypress");
    }
}

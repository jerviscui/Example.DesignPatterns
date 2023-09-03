internal interface IMediator
{
    //public event EventHandler Notify;
    public void Notify(object sender, string @event);
}

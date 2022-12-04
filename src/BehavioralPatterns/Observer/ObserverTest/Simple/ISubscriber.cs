namespace ObserverTest;

public interface ISubscriber
{
    /// <summary>
    /// Called when [updated].
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event.</param>
    public void OnUpdated(object sender, UpdateEvent e);
}

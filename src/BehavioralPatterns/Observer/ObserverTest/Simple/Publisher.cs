using System.Globalization;

namespace ObserverTest;

public class Publisher
{
    private readonly List<ISubscriber> _subscribers = new();

    /// <summary>
    /// Registers the subscriber.
    /// </summary>
    /// <param name="subscriber">The subscriber.</param>
    public void RegisterSubscriber(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    /// <summary>
    /// Removes the subscriber.
    /// </summary>
    /// <param name="subscriber">The subscriber.</param>
    public void RemoveSubscriber(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Update()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.OnUpdated(this,
                new UpdateEvent { Message = DateTime.Now.ToString(CultureInfo.InvariantCulture) });
        }
    }
}

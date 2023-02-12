namespace ObserverTest;

internal class SubscriberManager
{
    private readonly object _lockobj = new();

    private readonly Dictionary<Type, SubscriberStorage> _subscribers = new();

    public void Add(Type eventDataType, IEventHandler eventHandler)
    {
        //CopyOnWrite
        var newList = GetHandlers(eventDataType).ToList();
        newList.Add(eventHandler);

        _subscribers[eventDataType].Handlers = newList;
    }

    public void Remove(Type eventDataType, IEventHandler eventHandler)
    {
        var newList = GetHandlers(eventDataType).ToList();
        newList.Remove(eventHandler);

        _subscribers[eventDataType].Handlers = newList;
    }

    public List<IEventHandler> GetHandlers(Type key)
    {
        if (!_subscribers.TryGetValue(key, out var value))
        {
            lock (_lockobj)
            {
                if (!_subscribers.TryGetValue(key, out value))
                {
                    value = new SubscriberStorage();
                    _subscribers.Add(key, value);
                }
            }
        }

        return value.Handlers;
    }

    private class SubscriberStorage
    {
        public List<IEventHandler> Handlers { get; set; } = new();
    }
}

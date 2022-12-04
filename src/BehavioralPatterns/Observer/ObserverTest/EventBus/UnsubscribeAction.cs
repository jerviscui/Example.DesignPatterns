namespace ObserverTest;

public class UnsubscribeAction : IDisposable
{
    private readonly LocalEventBus _localEventBus;

    private readonly IEventHandler _eventHandler;

    private readonly Type _eventDataType;

    public UnsubscribeAction(LocalEventBus localEventBus, IEventHandler eventHandler, Type eventDataType)
    {
        _localEventBus = localEventBus;
        _eventHandler = eventHandler;
        _eventDataType = eventDataType;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _localEventBus.UnSubscribe(_eventDataType, _eventHandler);
    }
}

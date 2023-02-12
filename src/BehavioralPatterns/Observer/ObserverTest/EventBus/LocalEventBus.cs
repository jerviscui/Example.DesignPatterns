using System.Runtime.ExceptionServices;

namespace ObserverTest;

public class LocalEventBus
{
    private readonly SubscriberManager _subscriberManager;

    public LocalEventBus()
    {
        _subscriberManager = new SubscriberManager();
    }

    public IDisposable Subscribe<TData>(IEventHandler<TData> eventHandler) where TData : EventData
    {
        var type = typeof(TData);

        return Subscribe(type, eventHandler);
    }

    private IDisposable Subscribe(Type eventDataType, IEventHandler eventHandler)
    {
        _subscriberManager.Add(eventDataType, eventHandler);

        return new UnsubscribeAction(this, eventHandler, eventDataType);
    }

    public void UnSubscribe(Type eventDataType, IEventHandler eventHandler) =>
        _subscriberManager.Remove(eventDataType, eventHandler);

    public async Task PublishAsync<TData>(TData eventData) where TData : EventData
    {
        var type = eventData.GetType();
        var handlers = _subscriberManager.GetHandlers(type);

        var errors = new List<Exception>();

        foreach (var handler in handlers)
        {
            try
            {
                await ((IEventHandler<TData>)handler).HandleAsync(eventData);
            }
            catch (Exception e)
            {
                errors.Add(e);
            }
        }

        if (!errors.Any())
        {
            return;
        }

        if (errors.Count == 1)
        {
            ExceptionDispatchInfo.Throw(errors[0]);
        }
        else
        {
            throw new AggregateException($"More than one error when trigger the event: {type}", errors);
        }
    }
}

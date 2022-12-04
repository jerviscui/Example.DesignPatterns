using System.Runtime.ExceptionServices;

namespace ObserverTest;

public class LocalEventBus
{
    private readonly object _lockobj = new();

    private readonly Dictionary<Type, List<IEventHandler>> _subscribers = new();

    public IDisposable Subscribe<TData>(IEventHandler<TData> eventHandler) where TData : EventData
    {
        var type = typeof(TData);

        return Subscribe(type, eventHandler);
    }

    private IDisposable Subscribe(Type eventDataType, IEventHandler eventHandler)
    {
        GetHandlers(eventDataType).Add(eventHandler);

        return new UnsubscribeAction(this, eventHandler, eventDataType);
    }

    private List<IEventHandler> GetHandlers(Type key)
    {
        if (!_subscribers.TryGetValue(key, out var value))
        {
            lock (_lockobj)
            {
                if (!_subscribers.TryGetValue(key, out value))
                {
                    value = new List<IEventHandler>();
                    _subscribers.Add(key, value);
                }
            }
        }

        return value;
    }

    public void UnSubscribe(Type eventDataType, IEventHandler eventHandler)
    {
        GetHandlers(eventDataType).Remove(eventHandler);
    }

    public async Task PublishAsync<TData>(TData eventData) where TData : EventData
    {
        var type = eventData.GetType();
        var handlers = GetHandlers(type);

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

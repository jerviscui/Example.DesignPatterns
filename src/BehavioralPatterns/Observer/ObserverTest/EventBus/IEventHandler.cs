namespace ObserverTest;

public interface IEventHandler
{
}

public interface IEventHandler<TData> : IEventHandler where TData : EventData
{
    public Task HandleAsync(TData eventData);
}

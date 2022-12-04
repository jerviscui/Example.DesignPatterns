namespace ObserverTest;

public class ExceptionHandler : IEventHandler<ExceptionEventData>
{
    /// <inheritdoc />
    public Task HandleAsync(ExceptionEventData eventData)
    {
        throw new ApplicationException($"handle error, event: {eventData.GetType()}");
    }
}

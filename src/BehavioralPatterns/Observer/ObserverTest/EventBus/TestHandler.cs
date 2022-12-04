namespace ObserverTest;

public class TestHandler : IEventHandler<TestEventData>
{
    public int NotifyTimes { get; private set; }

    /// <inheritdoc />
    public Task HandleAsync(TestEventData eventData)
    {
        NotifyTimes++;
        var s = eventData.Message;

        return Task.CompletedTask;
    }
}

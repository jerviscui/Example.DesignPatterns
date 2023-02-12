namespace ObserverTest
{
    public class EventBusTests
    {
        [Fact]
        public async Task Publish_HandleError_Test()
        {
            var eventBus = new LocalEventBus();

            var handler = new ExceptionHandler();
            eventBus.Subscribe(handler);

            var eventData = new ExceptionEventData { Sender = this };

            await eventBus.PublishAsync(eventData).ShouldThrowAsync<ApplicationException>("handle throw exception");
        }

        [Fact]
        public async Task Publish_HandleErrors_AggregateException_Test()
        {
            var eventBus = new LocalEventBus();

            var handler = new ExceptionHandler();
            eventBus.Subscribe(handler);
            var handler2 = new ExceptionHandler();
            eventBus.Subscribe(handler2);

            var eventData = new ExceptionEventData { Sender = this };

            await eventBus.PublishAsync(eventData).ShouldThrowAsync<AggregateException>("more than one exceptions");
        }

        [Fact]
        public async Task Publish_HandlerBindEvent_Test()
        {
            var eventBus = new LocalEventBus();

            var handler = new TestHandler();
            eventBus.Subscribe(handler);

            var eventData = new TestEventData();
            await eventBus.PublishAsync(eventData);

            handler.NotifyTimes.ShouldBe(1);
        }

        [Fact]
        public async Task Publish_HandlerBindEvent_MultiSubs_Test()
        {
            var eventBus = new LocalEventBus();

            var handler = new TestHandler();
            eventBus.Subscribe(handler);

            var handler2 = new TestHandler();
            eventBus.Subscribe(handler2);

            var eventData = new TestEventData();
            await eventBus.PublishAsync(eventData);

            handler.NotifyTimes.ShouldBe(1);
            handler2.NotifyTimes.ShouldBe(1);
        }

        [Fact]
        public async Task Publish_HandlerBindEvent_NoTrigger_Test()
        {
            var eventBus = new LocalEventBus();

            var handler = new TestHandler();
            eventBus.Subscribe(handler);

            var eventData = new ExceptionEventData { Sender = this };
            await eventBus.PublishAsync(eventData);

            handler.NotifyTimes.ShouldBe(0);
        }

        [Fact]
        public async Task UnSubscribe_Test()
        {
            var eventBus = new LocalEventBus();

            var handler = new TestHandler();
            var unsub = eventBus.Subscribe(handler);

            unsub.Dispose();

            var eventData = new TestEventData();
            await eventBus.PublishAsync(eventData);

            handler.NotifyTimes.ShouldBe(0);
        }
    }
}

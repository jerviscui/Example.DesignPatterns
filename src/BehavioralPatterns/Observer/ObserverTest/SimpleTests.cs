using Moq;

namespace ObserverTest
{
    public class SimpleTests
    {
        [Fact]
        public void Update_WithSubscriber_Test()
        {
            var publisher = new Publisher();
            publisher.RegisterSubscriber(new MailSubscriber());
            publisher.RegisterSubscriber(new MessageSubscriber());

            publisher.Update();
        }

        [Fact]
        public void Update_WithoutSubscriber_Test()
        {
            var publisher = new Publisher();

            var mock = new Mock<ISubscriber>();
            publisher.RegisterSubscriber(mock.Object);

            publisher.Update();

            mock.Verify(o => o.OnUpdated(It.IsAny<object>(), It.IsAny<UpdateEvent>()), Times.Once);
        }
    }
}

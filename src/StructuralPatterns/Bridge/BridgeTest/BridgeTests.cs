namespace BridgeTest
{
    public class BridgeTests
    {
        [Fact]
        public void SimpleRemote_Radio_Test()
        {
            var radio = new Radio();
            Remote simple = new SimpleRemote(radio);

            simple.VolumeUp().ShouldBe<uint>(1);
            simple.VolumeDown().ShouldBe<uint>(0);
        }

        [Fact]
        public void SimpleRemote_SetChannel_NotImplementedException_Test()
        {
            var television = new Television();
            Remote simple = new SimpleRemote(television);

            ShouldThrowExtensions.ShouldThrow<NotImplementedException>(() => simple.SetChannel(1));
        }

        [Fact]
        public void SimpleRemote_Radio_MaxChannel_Test()
        {
            var radio = new Radio();
            Remote simple = new SimpleRemote(radio);

            for (int i = 0; i < Radio.MaxChannel; i++)
            {
                simple.ChannelUp();
            }

            simple.ChannelUp().ShouldBe<uint>(Radio.MaxChannel);
        }

        [Fact]
        public void SimpleRemote_Television_MaxChannel_Test()
        {
            var television = new Television();
            Remote simple = new SimpleRemote(television);

            for (int i = 0; i < Television.MaxChannel; i++)
            {
                simple.ChannelUp();
            }

            simple.ChannelUp().ShouldBe<uint>(1);
        }

        [Fact]
        public void AdvanceRemote_Radio_Test()
        {
            var radio = new Radio();
            Remote advance = new AdvanceRemote(radio);

            advance.VolumeUp().ShouldBe<uint>(1);
            advance.VolumeDown().ShouldBe<uint>(0);
        }

        [Fact]
        public void AdvanceRemote_Radio_SetChannel_Test()
        {
            var radio = new Radio();
            Remote advance = new AdvanceRemote(radio);

            advance.SetChannel(10).ShouldBe<uint>(0);
        }

        [Fact]
        public void AdvanceRemote_Television_SetChannel_Test()
        {
            var television = new Television();
            Remote advance = new AdvanceRemote(television);

            advance.SetChannel(13).ShouldBe<uint>(1);
        }
    }
}

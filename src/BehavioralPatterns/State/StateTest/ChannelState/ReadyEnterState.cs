namespace StateTest
{
    public class ReadyEnterState : ChannelState
    {
        /// <inheritdoc />
        public ReadyEnterState(ChannelStateContext channelStateContext) : base(channelStateContext)
        {
        }

        /// <inheritdoc />
        public override void PayFailed()
        {
            ChannelStateContext.SetCurrentState(new WaitState(ChannelStateContext));
            ChannelStateContext.IsRunning = false;
        }

        /// <inheritdoc />
        public override void BarredEntery()
        {
            ChannelStateContext.SetCurrentState(new WaitState(ChannelStateContext));
            ChannelStateContext.IsRunning = false;
        }

        /// <inheritdoc />
        public override void OpenDoor()
        {
            ChannelStateContext.SetCurrentState(new EnteringState(ChannelStateContext));
        }
    }
}

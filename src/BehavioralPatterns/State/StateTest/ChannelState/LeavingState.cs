namespace StateTest
{
    public class LeavingState : ChannelState
    {
        /// <inheritdoc />
        public LeavingState(ChannelStateContext channelStateContext) : base(channelStateContext)
        {
        }

        /// <inheritdoc />
        public override void Passed()
        {
            ChannelStateContext.SetCurrentState(new WaitState(ChannelStateContext));
            ChannelStateContext.IsRunning = false;
        }
    }
}

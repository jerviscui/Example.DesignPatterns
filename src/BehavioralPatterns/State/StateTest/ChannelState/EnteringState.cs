namespace StateTest.ChannelState;

public class EnteringState : ChannelState
{
    /// <inheritdoc />
    public EnteringState(ChannelStateContext channelStateContext) : base(channelStateContext)
    {
    }

    /// <inheritdoc />
    public override void Passed()
    {
        ChannelStateContext.SetCurrentState(new WaitState(ChannelStateContext));
        ChannelStateContext.IsRunning = false;
    }
}

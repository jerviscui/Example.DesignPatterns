namespace StateTest.ChannelState;

public class ReadyLeaveState : ChannelState
{
    /// <inheritdoc />
    public ReadyLeaveState(ChannelStateContext channelStateContext) : base(channelStateContext)
    {
    }

    /// <inheritdoc />
    public override void PayFailed()
    {
        ChannelStateContext.SetCurrentState(new WaitState(ChannelStateContext));
        ChannelStateContext.IsRunning = false;
    }

    /// <inheritdoc />
    public override void OpenDoor()
    {
        ChannelStateContext.SetCurrentState(new LeavingState(ChannelStateContext));
    }
}

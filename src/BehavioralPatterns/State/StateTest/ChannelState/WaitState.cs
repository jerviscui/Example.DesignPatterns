namespace StateTest.ChannelState;

/// <summary>
/// 等待识别
/// </summary>
public class WaitState : ChannelState
{
    /// <inheritdoc />
    public WaitState(ChannelStateContext channelStateContext) : base(channelStateContext)
    {
    }

    /// <inheritdoc />
    public override bool ReceiveNumber()
    {
        if (ChannelStateContext.IsRunning)
        {
            return false;
        }

        ChannelStateContext.IsRunning = true;
        ChannelStateContext.SetCurrentState(new RecognizingState(ChannelStateContext));

        return true;
    }

    /// <inheritdoc />
    public override void RecognizeFailed()
    {
        ChannelStateContext.SetCurrentState(new WaitState(ChannelStateContext));
        ChannelStateContext.IsRunning = false;
    }
}

namespace StateTest.ChannelState;

/// <summary>
/// 识别中
/// </summary>
public class RecognizingState : ChannelState
{
    /// <inheritdoc />
    public RecognizingState(ChannelStateContext channelStateContext) : base(channelStateContext)
    {
    }

    /// <inheritdoc />
    public override bool IsEnter(RecognizeEventData data)
    {
        if (!data.IsEnter)
        {
            return false;
        }

        if (data.Direction == Direction.OnlyOut)
        {
            return false;
        }

        ChannelStateContext.SetCurrentState(new ReadyEnterState(ChannelStateContext));

        return true;
    }

    /// <inheritdoc />
    public override bool IsLeave(RecognizeEventData data)
    {
        if (data.IsEnter)
        {
            return false;
        }

        if (data.Direction == Direction.OnlyIn)
        {
            return false;
        }

        ChannelStateContext.SetCurrentState(new ReadyLeaveState(ChannelStateContext));

        return true;
    }

    /// <inheritdoc />
    public override void RecognizeFailed()
    {
        ChannelStateContext.SetCurrentState(new WaitState(ChannelStateContext));
        ChannelStateContext.IsRunning = false;
    }
}

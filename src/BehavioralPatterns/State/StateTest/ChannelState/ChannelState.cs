using TestBase;

namespace StateTest.ChannelState;

/// <summary>
/// 通道状态
/// </summary>
/// <seealso cref="IChannelState" />
public abstract class ChannelState : IChannelState
{
    protected ChannelStateContext ChannelStateContext { get; set; }

    protected ChannelState(ChannelStateContext channelStateContext) => ChannelStateContext = channelStateContext;

    /// <inheritdoc />
    public virtual bool ReceiveNumber()
    {
        Logger.Log($"{GetType()}");
        return false;
    }

    /// <inheritdoc />
    public virtual void RecognizeFailed()
    {
        Logger.Log($"{GetType()}");
    }

    /// <inheritdoc />
    public virtual bool IsEnter(RecognizeEventData data)
    {
        Logger.Log($"{GetType()}");
        return false;
    }

    /// <inheritdoc />
    public virtual bool IsLeave(RecognizeEventData data)
    {
        Logger.Log($"{GetType()}");
        return false;
    }

    /// <inheritdoc />
    public virtual void OpenDoor()
    {
        Logger.Log($"{GetType()}");
    }

    /// <inheritdoc />
    public virtual void Passed()
    {
        Logger.Log($"{GetType()}");
    }

    /// <inheritdoc />
    public virtual void PayFailed()
    {
        Logger.Log($"{GetType()}");
    }

    /// <inheritdoc />
    public virtual void BarredEntery()
    {
        Logger.Log($"{GetType()}");
    }
}
namespace BridgeTest;

public abstract class Remote
{
    protected readonly IDevice Device;

    protected Remote(IDevice device) => Device = device;

    /// <summary>
    /// Toggles the power.
    /// </summary>
    public virtual void TogglePower()
    {
        if (Device.IsEnable)
        {
            Device.Disable();
        }
        else
        {
            Device.Enable();
        }
    }

    /// <summary>
    /// Volumes down.
    /// </summary>
    public abstract uint VolumeDown();

    /// <summary>
    /// Volumes up.
    /// </summary>
    public abstract uint VolumeUp();

    /// <summary>
    /// Channels down.
    /// </summary>
    public abstract uint ChannelDown();

    /// <summary>
    /// Channels up.
    /// </summary>
    public abstract uint ChannelUp();

    /// <summary>
    /// Sets the channel.
    /// </summary>
    /// <param name="channel">The channel.</param>
    public abstract uint SetChannel(uint channel);
}

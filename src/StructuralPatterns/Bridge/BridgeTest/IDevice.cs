namespace BridgeTest;

public interface IDevice
{
    /// <summary>
    /// Gets a value indicating whether this instance is enable.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is enable; otherwise, <c>false</c>.
    /// </value>
    public bool IsEnable { get; }

    /// <summary>
    /// Enables this instance.
    /// </summary>
    public void Enable();

    /// <summary>
    /// Disables this instance.
    /// </summary>
    public void Disable();

    /// <summary>
    /// Sets the volume.
    /// </summary>
    /// <param name="value">The value.</param>
    public void SetVolume(uint value);

    /// <summary>
    /// Gets the volume.
    /// </summary>
    /// <returns>current volume</returns>
    public uint GetVolume();

    /// <summary>
    /// Sets the channel.
    /// </summary>
    /// <param name="channel">The channel.</param>
    public void SetChannel(uint channel);

    /// <summary>
    /// Gets the channel.
    /// </summary>
    /// <returns>current channel</returns>
    public uint GetChannel();
}

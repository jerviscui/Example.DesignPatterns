namespace BridgeTest;

public class Radio : IDevice
{
    public const int MaxChannel = 5;

    /// <inheritdoc />
    public bool IsEnable { get; private set; }

    /// <inheritdoc />
    public void Enable() => IsEnable = true;

    /// <inheritdoc />
    public void Disable() => IsEnable = false;

    private uint _volume;

    /// <inheritdoc />
    public void SetVolume(uint value) => _volume = value;

    /// <inheritdoc />
    public uint GetVolume() => _volume;

    private uint _channel;

    /// <inheritdoc />
    public void SetChannel(uint channel)
    {
        if (channel is > 0 and <= MaxChannel)
        {
            _channel = channel;
        }
    }

    /// <inheritdoc />
    public uint GetChannel() => _channel;
}

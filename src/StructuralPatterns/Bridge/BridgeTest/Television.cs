namespace BridgeTest;

public class Television : IDevice
{
    public const uint MaxChannel = 12;

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
        //1..12 circulation, 参考补码减法溢出
        var tmp = channel % MaxChannel;
        _channel = tmp == 0 ? MaxChannel : tmp;
    }

    /// <inheritdoc />
    public uint GetChannel() => _channel;
}

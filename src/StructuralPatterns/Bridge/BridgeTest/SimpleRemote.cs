﻿namespace BridgeTest;

public class SimpleRemote : Remote
{
    /// <inheritdoc />
    public SimpleRemote(IDevice device) : base(device)
    {
    }

    /// <inheritdoc />
    public override uint VolumeDown()
    {
        Device.SetVolume(Device.GetVolume() - 1);

        return Device.GetVolume();
    }

    /// <inheritdoc />
    public override uint VolumeUp()
    {
        Device.SetVolume(Device.GetVolume() + 1);

        return Device.GetVolume();
    }

    /// <inheritdoc />
    public override uint ChannelDown()
    {
        Device.SetChannel(Device.GetChannel() - 1);

        return Device.GetChannel();
    }

    /// <inheritdoc />
    public override uint ChannelUp()
    {
        Device.SetChannel(Device.GetChannel() + 1);

        return Device.GetChannel();
    }

    /// <inheritdoc />
    public override uint SetChannel(uint channel) => throw new NotImplementedException();
}

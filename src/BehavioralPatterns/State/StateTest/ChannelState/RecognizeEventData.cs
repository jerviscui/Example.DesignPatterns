namespace StateTest.ChannelState;

public class RecognizeEventData
{
    public bool IsEnter { get; set; }

    public Direction Direction { get; set; }
}

public enum Direction
{
    OnlyIn,

    OnlyOut,

    Bothway
}

namespace StateTest.MarioStateEx;

public class SmallMarioState : MarioState
{
    /// <inheritdoc />
    public SmallMarioState(MarioStateContext marioStateContext) : base(marioStateContext)
    {
    }

    /// <inheritdoc />
    public override void ObtainSuper()
    {
        MarioStateContext.SetState(new SuperMarioState(MarioStateContext));
        MarioStateContext.SetScore(+100);
    }

    /// <inheritdoc />
    public override void ObtainCape()
    {
        MarioStateContext.SetState(new CapeMarioState(MarioStateContext));
    }

    /// <inheritdoc />
    public override void ObtainFire()
    {
        MarioStateContext.SetState(new FireMarioState(MarioStateContext));
    }
}

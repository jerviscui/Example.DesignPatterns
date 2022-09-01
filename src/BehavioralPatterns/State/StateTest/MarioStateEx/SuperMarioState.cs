namespace StateTest.MarioStateEx;

public class SuperMarioState : MarioState
{
    /// <inheritdoc />
    public SuperMarioState(MarioStateContext marioStateContext) : base(marioStateContext)
    {
    }

    /// <inheritdoc />
    public override void TouchMonster()
    {
        MarioStateContext.SetState(new SmallMarioState(MarioStateContext));
        MarioStateContext.SetScore(-100);
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

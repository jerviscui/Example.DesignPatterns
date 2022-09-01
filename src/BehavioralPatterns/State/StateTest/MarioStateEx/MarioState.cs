namespace StateTest.MarioStateEx;

public abstract class MarioState : IMarioState
{
    public MarioStateContext MarioStateContext { get; set; }

    protected MarioState(MarioStateContext marioStateContext)
    {
        MarioStateContext = marioStateContext;
        MarioStateContext.StateChanged += Exit;

        Entry();
    }

    /// <inheritdoc />
    public virtual void ObtainCape()
    {
        Do();
    }

    /// <inheritdoc />
    public virtual void ObtainFire()
    {
        Do();
    }

    /// <inheritdoc />
    public virtual void ObtainSuper()
    {
        Do();
    }

    /// <inheritdoc />
    public virtual void TouchMonster()
    {
        Do();
    }

    /// <summary>
    /// 进入行为
    /// </summary>
    protected virtual void Entry()
    {
    }

    /// <summary>
    /// 激活行为
    /// </summary>
    protected virtual void Do()
    {
    }

    /// <summary>
    /// 退出行为
    /// </summary>
    protected virtual void Exit()
    {
    }
}

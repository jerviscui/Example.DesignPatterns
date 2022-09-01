using System;

namespace StateTest.MarioStateEx;

public sealed class MarioStateContext : IMarioState
{
    public MarioStateContext()
    {
        CurrentState = new SmallMarioState(this);
    }

    public IMarioState CurrentState { get; private set; }

    public int Score { get; private set; }

    internal void SetScore(int score)
    {
        Score += score;
    }

    internal void SetState(IMarioState state)
    {
        StateChanged.Invoke();
        CurrentState = state;
    }

    internal event Action StateChanged;

    /// <inheritdoc />
    public void ObtainCape()
    {
        CurrentState.ObtainCape();
    }

    /// <inheritdoc />
    public void ObtainFire()
    {
        CurrentState.ObtainFire();
    }

    /// <inheritdoc />
    public void ObtainSuper()
    {
        CurrentState.ObtainSuper();
    }

    /// <inheritdoc />
    public void TouchMonster()
    {
        CurrentState.TouchMonster();
    }
}
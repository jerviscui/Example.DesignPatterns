namespace StateTest.MarioState;

public class MarioStateMachine
{
    /// <summary>
    /// Change score actions
    /// </summary>
    private readonly int[][] ChangeScoreTable =
    {
        //Cape
        new[] { 0, 0, -200, 0 },
        //Fire
        new[] { 0, 0, -300, 0 },
        //Small
        new[] { +200, +300, 0, +100 },
        //Super
        new[] { +200, +300, -100, 0 }
    };

    /// <summary>
    /// 状态转移表
    /// </summary>
    private readonly State[][] StatesTable =
    {
        //Cape
        new[] { State.Cape, State.Cape, State.Small, State.Cape },
        //Fire
        new[] { State.Fire, State.Fire, State.Small, State.Fire },
        //Small
        new[] { State.Cape, State.Fire, State.Small, State.Super },
        //Super
        new[] { State.Cape, State.Fire, State.Small, State.Super }
    };

    public MarioStateMachine()
    {
        Score = 0;
        CurrentState = State.Small;
    }

    public int Score { get; private set; }

    public State CurrentState { get; private set; }

    private void ChangeScore(int score)
    {
        Score += score;
    }

    //private void FireEntry()
    //{
    //    Score += 300;
    //}

    //private void CapeEntry()
    //{
    //    Score += 200;
    //}

    //private void DoEntry()
    //{
    //    if (CurrentState == State.Cape)
    //    {
    //        CapeEntry();
    //    }
    //    else if (CurrentState == State.Fire)
    //    {
    //        FireEntry();
    //    }
    //}

    private void Excute(State nextState)
    {
        var row = (int)CurrentState;
        var column = (int)nextState;

        CurrentState = StatesTable[row][column];
        ChangeScore(ChangeScoreTable[row][column]);
    }

    /// <summary>
    /// 获得斗篷
    /// </summary>
    public void ObtainCape()
    {
        Excute(State.Cape);

        //DoEntry();
    }

    /// <summary>
    /// 获得火焰
    /// </summary>
    public void ObtainFire()
    {
        Excute(State.Fire);
    }

    /// <summary>
    /// 获得大个
    /// </summary>
    public void ObtainSuper()
    {
        Excute(State.Super);
    }

    /// <summary>
    /// 接触怪物
    /// </summary>
    public void TouchMonster()
    {
        Excute(State.Small);
    }
}

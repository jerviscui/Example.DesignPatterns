using Shouldly;
using StateTest.MarioState;
using TestBase;
using Xunit;

namespace StateTest;

public class MarioStateTests : BaseTest
{
    private readonly MarioStateMachine _marioStateMachine;

    public MarioStateTests()
    {
        _marioStateMachine = new MarioStateMachine();
    }

    [Fact]
    public void ObtainCape_Once_StateIsCape()
    {
        _marioStateMachine.ObtainCape();

        _marioStateMachine.Score.ShouldBe(200);
        _marioStateMachine.CurrentState.ShouldBe(State.Cape);
    }

    [Fact]
    public void ObtainSuper_Once_StateIsSuper()
    {
        _marioStateMachine.ObtainSuper();

        _marioStateMachine.Score.ShouldBe(100);
        _marioStateMachine.CurrentState.ShouldBe(State.Super);
    }

    [Fact]
    public void ObtainSuper_Once_StateIsFire()
    {
        _marioStateMachine.ObtainFire();

        _marioStateMachine.Score.ShouldBe(300);
        _marioStateMachine.CurrentState.ShouldBe(State.Fire);
    }

    [Fact]
    public void TouchMonster_Once_StateIsSmall()
    {
        _marioStateMachine.TouchMonster();

        _marioStateMachine.Score.ShouldBe(0);
        _marioStateMachine.CurrentState.ShouldBe(State.Small);
    }

    [Fact]
    public void Sample_Test()
    {
        //sample:
        //Super Fire    Fire    Small   Small   Cape    => Cape
        //+100  +300    +0      -300    +0      +200     => 300

        _marioStateMachine.ObtainSuper();
        _marioStateMachine.ObtainFire();
        _marioStateMachine.ObtainFire();
        _marioStateMachine.TouchMonster();
        _marioStateMachine.TouchMonster();
        _marioStateMachine.ObtainCape();

        _marioStateMachine.CurrentState.ShouldBe(State.Cape);
        _marioStateMachine.Score.ShouldBe(300);
    }
}

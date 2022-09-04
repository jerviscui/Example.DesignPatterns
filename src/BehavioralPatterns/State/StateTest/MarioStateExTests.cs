using StateTest.MarioStateEx;
using TestBase;

namespace StateTest;

public class MarioStateExTests : BaseTest
{
    private readonly MarioStateContext _marioStateContext;

    public MarioStateExTests()
    {
        _marioStateContext = new MarioStateContext();
    }

    [Fact]
    public void ObtainCape_Once_StateIsCape()
    {
        _marioStateContext.ObtainCape();

        _marioStateContext.Score.ShouldBe(200);
        _marioStateContext.CurrentState.GetType().ShouldBe(typeof(CapeMarioState));
    }

    [Fact]
    public void ObtainSuper_Once_StateIsSuper()
    {
        _marioStateContext.ObtainSuper();

        _marioStateContext.Score.ShouldBe(100);
        _marioStateContext.CurrentState.GetType().ShouldBe(typeof(SuperMarioState));
    }

    [Fact]
    public void ObtainSuper_Once_StateIsFire()
    {
        _marioStateContext.ObtainFire();

        _marioStateContext.Score.ShouldBe(300);
        _marioStateContext.CurrentState.GetType().ShouldBe(typeof(FireMarioState));
    }

    [Fact]
    public void TouchMonster_Once_StateIsSmall()
    {
        _marioStateContext.TouchMonster();

        _marioStateContext.Score.ShouldBe(0);
        _marioStateContext.CurrentState.GetType().ShouldBe(typeof(SmallMarioState));
    }

    [Fact]
    public void Sample_Test()
    {
        //sample:
        //Super Fire    Fire    Small   Small   Cape    => Cape
        //+100  +300    +0      -300    +0      +200     => 300

        _marioStateContext.ObtainSuper();
        _marioStateContext.ObtainFire();
        _marioStateContext.ObtainFire();
        _marioStateContext.TouchMonster();
        _marioStateContext.TouchMonster();
        _marioStateContext.ObtainCape();

        _marioStateContext.CurrentState.GetType().ShouldBe(typeof(CapeMarioState));
        _marioStateContext.Score.ShouldBe(300);
    }
}

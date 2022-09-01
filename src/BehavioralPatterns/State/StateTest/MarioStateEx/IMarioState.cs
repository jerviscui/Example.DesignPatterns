namespace StateTest.MarioStateEx;

public interface IMarioState
{
    /// <summary>
    /// 获得斗篷
    /// </summary>
    public void ObtainCape();

    /// <summary>
    /// 获得火焰
    /// </summary>
    public void ObtainFire();

    /// <summary>
    /// 获得大个
    /// </summary>
    public void ObtainSuper();

    /// <summary>
    /// 接触怪物
    /// </summary>
    public void TouchMonster();
}

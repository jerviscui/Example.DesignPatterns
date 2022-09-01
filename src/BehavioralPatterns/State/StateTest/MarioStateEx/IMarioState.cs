namespace StateTest.MarioStateEx;

public interface IMarioState
{
    /// <summary>
    /// ��ö���
    /// </summary>
    public void ObtainCape();

    /// <summary>
    /// ��û���
    /// </summary>
    public void ObtainFire();

    /// <summary>
    /// ��ô��
    /// </summary>
    public void ObtainSuper();

    /// <summary>
    /// �Ӵ�����
    /// </summary>
    public void TouchMonster();
}

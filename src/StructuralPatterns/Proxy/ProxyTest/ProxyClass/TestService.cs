namespace ProxyTest.ProxyClass;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class DontProxyAttribute : Attribute
{
}

internal interface ITestService
{
    public void ReturnVoid(int x, int y);

    public void ReturnVoid(TestArg arg);

    public TestArg ReturnArg(ref TestArg arg);

    [DontProxy]
    public TestArg ReturnArgNoProxy();
}

internal class TestService : ITestService
{
    public void ReturnVoid(int x, int y)
    {
        int i = x + y;
    }

    public void ReturnVoid(TestArg arg)
    {
        var i = arg.I;
        var s = arg.S;
    }

    public TestArg ReturnArg(ref TestArg arg)
    {
        return new TestArg { I = arg.I, S = arg.S };
    }

    [DontProxy]
    public TestArg ReturnArgNoProxy()
    {
        return new TestArg();
    }
}

internal class TestArg
{
    public string S { get; set; }

    public int I { get; set; }
}

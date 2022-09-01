namespace SingletonTest;

public class StaticSingleton
{
    private StaticSingleton()
    {
    }

    private static readonly StaticSingleton Singleton = new();

    public static StaticSingleton GetInstance() => Singleton;
}

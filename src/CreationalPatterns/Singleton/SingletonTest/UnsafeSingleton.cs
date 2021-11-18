namespace SingletonTest
{
    public class UnsafeSingleton
    {
        private UnsafeSingleton()
        {
        }

        private static UnsafeSingleton? _singleton;

        public static UnsafeSingleton GetInstance() => _singleton ??= new UnsafeSingleton();
    }
}

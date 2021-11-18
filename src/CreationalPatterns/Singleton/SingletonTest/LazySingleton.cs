namespace SingletonTest
{
    public class LazySingleton
    {
        private LazySingleton()
        {
        }

        public static LazySingleton GetInstance() => Nested.Singleton;

        private static class Nested
        {
            internal static readonly LazySingleton Singleton = new();
        }
    }
}

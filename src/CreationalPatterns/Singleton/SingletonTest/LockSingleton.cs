namespace SingletonTest
{
    public class LockSingleton
    {
        private LockSingleton()
        {
        }

        private static LockSingleton? _singleton;

        private static readonly object Lock = new();

        public static LockSingleton GetInstance()
        {
            if (_singleton is null)
            {
                lock (Lock)
                {
                    _singleton ??= new LockSingleton();
                }
            }

            return _singleton;
        }
    }
}

using System.Threading;

namespace SingletonTest
{
    public class InterlockedSingleton
    {
        private InterlockedSingleton()
        {
        }

        private static InterlockedSingleton? _singleton;

        public static InterlockedSingleton GetInstance()
        {
            Interlocked.CompareExchange(ref _singleton, new InterlockedSingleton(), null);

            return _singleton;
        }
    }
}

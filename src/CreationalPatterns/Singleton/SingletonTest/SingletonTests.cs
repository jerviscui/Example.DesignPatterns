using System.Threading.Tasks;
using Shouldly;
using TestBase;
using Xunit;

namespace SingletonTest
{
    public class SingletonTests : BaseTest
    {
        [Fact]
        public void UnsafeSingleton_Test()
        {
            var t1 = Task.Run(UnsafeSingleton.GetInstance);
            var t2 = Task.Run(UnsafeSingleton.GetInstance);

            Task.WaitAll(t1, t2);
            t1.Result.ShouldNotBe(t2.Result);
        }

        [Fact]
        public void LockSingleton_Test()
        {
            var t1 = Task.Run(LockSingleton.GetInstance);
            var t2 = Task.Run(LockSingleton.GetInstance);

            Task.WaitAll(t1, t2);
            t1.Result.ShouldBe(t2.Result);
        }

        [Fact]
        public void InterlockedSingleton_Test()
        {
            var t1 = Task.Run(InterlockedSingleton.GetInstance);
            var t2 = Task.Run(InterlockedSingleton.GetInstance);

            Task.WaitAll(t1, t2);
            t1.Result.ShouldBe(t2.Result);
        }

        [Fact]
        public void StaticSingleton_Test()
        {
            var t1 = Task.Run(StaticSingleton.GetInstance);
            var t2 = Task.Run(StaticSingleton.GetInstance);

            Task.WaitAll(t1, t2);
            t1.Result.ShouldBe(t2.Result);
        }

        [Fact]
        public void LazySingleton_Test()
        {
            var t1 = Task.Run(LazySingleton.GetInstance);
            var t2 = Task.Run(LazySingleton.GetInstance);

            Task.WaitAll(t1, t2);
            t1.Result.ShouldBe(t2.Result);
        }
    }
}

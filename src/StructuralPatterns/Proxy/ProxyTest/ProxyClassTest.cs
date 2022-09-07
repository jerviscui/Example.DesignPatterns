using System.Reflection;
using ProxyTest.ProxyClass;

namespace ProxyTest
{
    public class ProxyClassTest
    {
        [Fact]
        public void DispatchProxy_Test()
        {
            var proxy = DispatchProxy.Create<ITestService, TestDispatchProxy>();

            (proxy as TestDispatchProxy).ShouldNotBeNull();
        }

        [Fact]
        public void TestDispatchProxy_WithNoInstance_Test()
        {
            var proxy = DispatchProxy.Create<ITestService, TestDispatchProxy>();

            ShouldThrowExtensions.ShouldThrow<StackOverflowException>(() => proxy.ReturnVoid(1, 2));
        }

        [Fact]
        public void TestDispatchProxy_WithInstance_Test()
        {
            var proxy = DispatchProxy.Create<ITestService, TestDispatchProxy>();
            ((TestDispatchProxy)proxy).Wrap = new TestService();

            proxy.ReturnVoid(1, 2);
        }

        [Fact]
        public void TestDispatchProxy_WithInstance_Predicate_Test()
        {
            var service = DispatchProxy.Create<ITestService, TestDispatchProxy>();
            var proxy = (TestDispatchProxy)service;
            proxy.Wrap = new TestService();
            proxy.Predicate = method => method.GetCustomAttribute<DontProxyAttribute>() is null;
            proxy.OnAfter = (info, objects, arg3) => new TestArg { I = 100 };

            var arg = new TestArg { I = 1 };
            var return1 = service.ReturnArg(ref arg);
            var return2 = service.ReturnArgNoProxy();

            return1.I.ShouldBe(100);
            return2.I.ShouldBe(0);
        }
    }
}

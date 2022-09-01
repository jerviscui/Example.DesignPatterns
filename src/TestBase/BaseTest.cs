using System;
using Microsoft.Extensions.DependencyInjection;

namespace TestBase;

public abstract class BaseTest
{
    public IServiceProvider ServiceProvider { get; set; }

    protected BaseTest()
    {
        var services = new ServiceCollection();

        Add(services);

        ServiceProvider = services.BuildServiceProvider();
    }

    protected virtual void Add(ServiceCollection services)
    {
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Moongazing.LightInject.Container;

public class ServiceCollection : IServiceCollection
{
    private readonly List<ServiceDescriptor> services = new();

    public void AddSingleton<TService, TImplementation>() where TImplementation : TService
    {
        services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
    }

    public void AddTransient<TService, TImplementation>() where TImplementation : TService
    {
        services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
    }

    public void AddScoped<TService, TImplementation>() where TImplementation : TService
    {
        services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Scoped));
    }

    public ServiceProvider BuildServiceProvider()
    {
        var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        foreach (var service in services)
        {
            serviceCollection.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor(service.ServiceType, service.ImplementationType, (Microsoft.Extensions.DependencyInjection.ServiceLifetime)service.Lifetime));
        }
        return serviceCollection.BuildServiceProvider();
    }
}

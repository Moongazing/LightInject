using Moongazing.LightInject.Exceptions;
using Moongazing.LightInject.Models;

namespace Moongazing.LightInject.Container;

public class ServiceProvider
{
    private readonly Dictionary<Type, ServiceDescriptor> serviceDescriptors = new();

    public ServiceProvider(IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        foreach (var descriptor in serviceDescriptors)
        {
            this.serviceDescriptors[descriptor.ServiceType] = descriptor;
        }
    }

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }

    private object GetService(Type serviceType)
    {
        if (!serviceDescriptors.TryGetValue(serviceType, out var descriptor))
        {
            throw new ServiceNotRegisteredException($"Service of type {serviceType.Name} is not registered.");
        }

        if (descriptor.Lifetime == ServiceLifetime.Singleton)
        {
            if (descriptor.ImplementationInstance == null)
            {
                descriptor.ImplementationInstance = CreateInstance(descriptor.ImplementationType);
            }
            return descriptor.ImplementationInstance;
        }

        if (descriptor.Lifetime == ServiceLifetime.Transient)
        {
            return CreateInstance(descriptor.ImplementationType);
        }

        throw new NotImplementedException("Scoped lifetime is not implemented in this example.");
    }

    private object CreateInstance(Type implementationType)
    {
        var constructor = implementationType.GetConstructors().First();
        var parameters = constructor.GetParameters()
            .Select(param => GetService(param.ParameterType))
            .ToArray();

        return Activator.CreateInstance(implementationType, parameters)!;
    }
}
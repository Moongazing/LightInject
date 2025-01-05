using Microsoft.Extensions.DependencyInjection;
using System;

namespace Moongazing.LightInject.Container;

public interface IServiceCollection
{
    void AddSingleton<TService, TImplementation>() where TImplementation : TService;
    void AddTransient<TService, TImplementation>() where TImplementation : TService;
    void AddScoped<TService, TImplementation>() where TImplementation : TService;
    ServiceProvider BuildServiceProvider();
}
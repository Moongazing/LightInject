LightInject

LightInject is a lightweight and minimal Dependency Injection (DI) framework for .NET 8. It provides support for constructor injection, interface injection, and configurable service lifetimes (Singleton, Transient, Scoped).
Features

    Constructor Injection: Automatically resolves dependencies through constructors.
    Service Lifetimes:
        Singleton: A single instance shared across the application.
        Transient: A new instance created every time the service is requested.
        Scoped: (To be implemented) A single instance per scope (e.g., HTTP request).
    Lightweight and Extendable: Designed for simplicity and performance, while allowing future enhancements.
    Custom Exception Handling: Provides detailed error messages for unregistered services.

Installation

Clone the repository and add the LightInject project to your solution.

git clone https://github.com/your-repo/lightinject.git

Reference the LightInject Class Library in your project.
Getting Started

Here’s how to use LightInject in your .NET project.
1. Configure Services

Use the ServiceCollection to register your dependencies.

using LightInject;

IServiceCollection services = new ServiceCollection();

// Register services
services.AddSingleton<IGreeter, ConsoleGreeter>();
services.AddTransient<IMessageService, MessageService>();

var provider = services.BuildServiceProvider();

2. Resolve Services

Use the ServiceProvider to resolve your dependencies.

var messageService = provider.GetService<IMessageService>();
messageService.SendMessage("Hello, Dependency Injection Framework!");

Example

Here’s a complete example of setting up and using LightInject.
Interfaces

public interface IGreeter
{
    void Greet(string message);
}

public interface IMessageService
{
    void SendMessage(string message);
}

Implementations

public class ConsoleGreeter : IGreeter
{
    public void Greet(string message)
    {
        Console.WriteLine($"[ConsoleGreeter]: {message}");
    }
}

public class MessageService : IMessageService
{
    private readonly IGreeter _greeter;

    public MessageService(IGreeter greeter)
    {
        _greeter = greeter;
    }

    public void SendMessage(string message)
    {
        _greeter.Greet(message);
    }
}

Program.cs

using LightInject;

class Program
{
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        // Register services
        services.AddSingleton<IGreeter, ConsoleGreeter>();
        services.AddTransient<IMessageService, MessageService>();

        var provider = services.BuildServiceProvider();

        // Resolve and use services
        var messageService = provider.GetService<IMessageService>();
        messageService.SendMessage("Hello, Dependency Injection Framework!");
    }
}

Design Overview

    ServiceCollection:
    Manages the registration of services and their lifetimes.

    ServiceProvider:
    Resolves registered services and their dependencies.

    ServiceDescriptor:
    Represents a service type, implementation type, and lifetime.

    ServiceNotRegisteredException:
    Custom exception thrown when a service is not registered.

Future Enhancements

    Add support for Scoped lifetimes.
    Integration with ASP.NET Core Middleware.
    Support for resolving services via method injection.
    Add benchmarks to measure performance under different scenarios.

Contributing

We welcome contributions! Please follow these steps:

    Fork the repository.
    Create a new branch for your feature or bug fix.
    Commit your changes with clear and descriptive messages.
    Submit a pull request.

License

This project is licensed under the MIT License. See the LICENSE file for details.
Contact

If you have any questions or suggestions, feel free to reach out:

    Email: tunahan.ali.ozturk@outlook.com
    

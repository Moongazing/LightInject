namespace Moongazing.LightInject.Exceptions;

public class ServiceNotRegisteredException : Exception
{
    public ServiceNotRegisteredException(string message) : base(message) { }
}
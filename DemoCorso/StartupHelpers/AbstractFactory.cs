using System;

namespace DemoCorso.StartupHelpers;

public class AbstractFactory<T> : IAbstractFactory<T> where T : class
{
    private readonly Func<T> factory;

    public AbstractFactory(Func<T> factory)
    {
        this.factory = factory;
    }

    public T Create()
    {
        return factory();
    }
}

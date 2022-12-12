namespace DemoCorso.StartupHelpers;

public interface IAbstractFactory<T>
{
    T Create();
}

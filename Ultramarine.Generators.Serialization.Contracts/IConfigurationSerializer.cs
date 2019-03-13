namespace Ultramarine.Generators.Serialization.Contracts
{
    public interface IConfigurationSerializer<T>
    {
        T Load();
    }
}

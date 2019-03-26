namespace Ultramarine.Workspaces
{
    public interface ILogger
    {
        void Info(string messageFormat, params string[] parameters);
        void Warn(string messageFormat, params string[] parameters);
    }
}

using Zenject;

namespace Common
{
    public interface IInstallHandler
    {
        void InstallBindings(DiContainer container);
        void Start(DiContainer container);
    }
}
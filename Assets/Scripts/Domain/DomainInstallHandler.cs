using Common;
using Domain.Boundaries;
using Zenject;

namespace Domain
{
    public class DomainInstallHandler : IInstallHandler
    {
        public void InstallBindings(DiContainer container)
        {
            container.Bind<ICalculatorEntryProcessor>().To<CalculatorEntryProcessor>().AsSingle();
            container.Bind<ICalculatorOperationsController>().To<CalculatorOperationsController>().AsSingle();
            container.Bind<IPersistentDataProvider>().To<PersistentDataProvider>().AsSingle();
        }

        public void Start(DiContainer container)
        {
            container.Resolve<ICalculatorOperationsController>().Initialize();
        }
    }
}
using Common;
using Domain;
using Presentation;
using Zenject;

namespace Installers
{
    public class CalculatorMonoInstaller : MonoInstaller
    {
        private IInstallHandler[] installHandlers;

        public override void Start()
        {
            base.Start();
            foreach (var handler in installHandlers) handler.Start(Container);
        }

        public override void InstallBindings()
        {
            installHandlers = new IInstallHandler[]
            {
                new DomainInstallHandler(),
                new PresentationInstallHandler()
            };
            foreach (var handler in installHandlers) handler.InstallBindings(Container);
        }
    }
}
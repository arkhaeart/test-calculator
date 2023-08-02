using Common;
using Presentation.Boundaries;
using Zenject;

namespace Presentation
{
    public class PresentationInstallHandler : IInstallHandler
    {
        public void InstallBindings(DiContainer container)
        {
            container.Bind<IAppStateListener>().To<AppStateListener>().FromNewComponentOnNewGameObject().AsSingle();
            container.Bind(typeof(ICalculatorPresenter), typeof(ICalculatorStarter))
                .To<CalculatorPresenter>()
                .AsSingle();
        }

        public void Start(DiContainer container)
        {
            container.Resolve<ICalculatorStarter>().Start().Forget();
        }
    }
}
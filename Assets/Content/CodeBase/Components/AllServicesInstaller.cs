using Content.CodeBase.Infrastructure.Services;
using Zenject;

namespace Content.CodeBase.Components
{
    public class AllServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlatformsFactory>().To<PlatformsFactory>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IInputService>().To<MobileInputService>().AsSingle();
            Container.Bind<IUnitDataService>().To<UnitDataService>().AsSingle();
        }
    }
}


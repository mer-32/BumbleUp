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
            Container.Bind<IPlatformsManager>().To<PlatformsManager>().AsSingle();
            Container.Bind<IUnitsFactory>().To<UnitsFactory>().AsSingle();

            Container.Bind<CameraManager>().FromNew().AsSingle();
        }
    }
}
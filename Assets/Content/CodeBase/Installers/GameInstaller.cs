using Content.CodeBase.Components;
using Content.CodeBase.Infrastructure;
using Content.CodeBase.Infrastructure.States;
using Zenject;

namespace Content.CodeBase.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle();
            
            BindStates();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }

        private void BindStates()
        {
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<GameEndState>().AsSingle();
        }
    }
}
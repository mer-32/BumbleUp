using Content.CodeBase.Signals;
using Zenject;

namespace Content.CodeBase.Components
{
    public class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<ScoreChangedSignal>();
        }
    }
}
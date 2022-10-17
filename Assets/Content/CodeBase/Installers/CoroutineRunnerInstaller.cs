using Content.CodeBase.Components;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Installers
{
    public class CoroutineRunnerInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            Container.Bind<CoroutineRunner>().FromInstance(_coroutineRunner);
        }
    }
}
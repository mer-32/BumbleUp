using Cinemachine;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineVirtualCamera _camera;

        public override void InstallBindings()
        {
            Container.Bind<CinemachineVirtualCamera>().FromInstance(_camera);
        }
    }
}
using Cinemachine;
using UnityEngine;

namespace Content.CodeBase.Infrastructure.Services
{
    public class CameraManager
    {
        private CinemachineVirtualCamera _camera;
        
        private CameraManager(CinemachineVirtualCamera camera)
        {
            _camera = camera;
        }

        public void SetTarget(Transform target)
        {
            _camera.Follow = target;
            _camera.LookAt = target;
        }
    }
}
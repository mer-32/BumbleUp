using System.Collections.Generic;
using Cinemachine;
using Content.CodeBase.Infrastructure.Assets;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Content.CodeBase.Infrastructure.Services
{
    public class PlatformsFactory : IPlatformsFactory
    {
        [Inject] private readonly CinemachineVirtualCamera _camera;

        private readonly List<Transform> _platforms = new List<Transform>();
        private readonly Vector3 _jumpVector = new Vector3(0, 2, 2);
        
        private Vector3 _platformSize;
        
        private const int TARGET_PLATFORM_NUM = 4;

        public Vector3 JumpVector => _jumpVector;

        public List<Transform> Platforms => _platforms;

        public Vector3 PlatformSize => _platformSize;


        public void CreatePlatforms()
        {
            Transform prefab = Resources.Load<Transform>(AssetPath.PLATFORM);

            for (int i = 0; i < 10; i++)
            {
                var transform = Object.Instantiate(prefab, i * _jumpVector, Quaternion.identity);
                _platforms.Add(transform);
            }
            
            _camera.Follow = _platforms[TARGET_PLATFORM_NUM];
            _platformSize = _platforms[TARGET_PLATFORM_NUM].GetChild(0).transform.localScale;
        }

        public void SwapPlatforms()
        {
            Transform firstPlatform = _platforms[0];
            Transform lastPlatform = _platforms[_platforms.Count - 1];
            firstPlatform.position = lastPlatform.position + _jumpVector;
            
            _platforms.Remove(firstPlatform);
            _platforms.Add(firstPlatform);
            
            _camera.Follow = _platforms[TARGET_PLATFORM_NUM];
        }
        
        public Transform GetPlatform(int num = 0, bool isTargetPlatform = false)
        {
            int platformNum = isTargetPlatform ? TARGET_PLATFORM_NUM : num;
            return _platforms[platformNum];
        }
    }
}
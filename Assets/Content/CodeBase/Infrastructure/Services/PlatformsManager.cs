using System.Collections.Generic;
using UnityEngine;

namespace Content.CodeBase.Infrastructure.Services
{
    public class PlatformsManager : IPlatformsManager
    {
        private const int TARGET_PLATFORM_NUM = 4;

        private readonly List<Transform> _platforms = new List<Transform>();
        
        private readonly Vector3 _platformStep = new Vector3(0, 2, 2);
        
        private Vector3 _platformSize;

        private CameraManager _cameraManager;

        private PlatformsManager(CameraManager cameraManager)
        {
            _cameraManager = cameraManager;
        }

        public void Init()
        {
            _platformSize = _platforms[TARGET_PLATFORM_NUM].GetChild(0).transform.localScale;
            _cameraManager.SetTarget(GetTargetPlatform());
        }

        public void SwapPlatforms()
        {
            Transform firstPlatform = _platforms[0];
            Transform lastPlatform = _platforms[_platforms.Count - 1];
            firstPlatform.position = lastPlatform.position + _platformStep;
            
            _platforms.Remove(firstPlatform);
            _platforms.Add(firstPlatform);
            
            _cameraManager.SetTarget(GetTargetPlatform());
        }

        public void AddPlatform(Transform transform) => _platforms.Add(transform);

        public Transform GetPlatform(int num = 0) => _platforms[num];

        public Transform GetTargetPlatform() =>_platforms[TARGET_PLATFORM_NUM];

        public List<Transform> GetPlatforms() => _platforms;

        public Vector3 GetPlatformStep() => _platformStep;

        public Vector3 GetPlatformSize() => _platformSize;

        public Vector3 GetRandomPos(float offsetX = 0)
        {
            float halfPlatform = _platformSize.x / 2 + offsetX;
            return Random.Range(-halfPlatform, halfPlatform) * Vector3.right;
        }
    }
}
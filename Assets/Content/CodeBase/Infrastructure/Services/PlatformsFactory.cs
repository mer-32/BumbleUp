using Content.CodeBase.Infrastructure.Assets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Content.CodeBase.Infrastructure.Services
{
    public class PlatformsFactory : IPlatformsFactory
    {
        private IPlatformsManager _platformsManager;

        private PlatformsFactory(IPlatformsManager platformsManager)
        {
            _platformsManager = platformsManager;
        }

        public void CreatePlatforms()
        {
            Transform prefab = Resources.Load<Transform>(AssetPath.PLATFORM);

            for (int i = 0; i < 10; i++)
            {
                var transform = Object.Instantiate(prefab, i * _platformsManager.GetPlatformStep(), Quaternion.identity);
                _platformsManager.AddPlatform(transform);
            }
            
            _platformsManager.Init();
        }
    }
}
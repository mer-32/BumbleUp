using Content.CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Infrastructure.Assets
{
    public class AssetProviderZenject : IAssetProvider
    {
        private readonly DiContainer _diContainer;
        
        public AssetProviderZenject(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Instantiate<T>(string path) where T : Object
        {
            var obj = _diContainer.InstantiatePrefabResource(path);
            
            return obj.GetComponent<T>();
        }

        public T InstantiateAt<T>(string path, Vector3 at) where T : Object
        {
            var obj = _diContainer.InstantiatePrefabResource(path, at, Quaternion.identity, null);
            
            return obj.GetComponent<T>();
        }
    }
}
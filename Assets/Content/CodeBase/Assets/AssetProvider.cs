using UnityEngine;

namespace Content.CodeBase.Infrastructure.Assets
{
    public class AssetProvider : IAssetProvider
    {
        public T Instantiate<T>(string path) where T : Object
        {
            var prefab = Resources.Load<T>(path);
            var obj = Object.Instantiate(prefab);
            return obj;
        }

        public T InstantiateAt<T>(string path, Vector3 at) where T : Object
        {
            var prefab = Resources.Load<T>(path);
            var obj = Object.Instantiate(prefab, at, Quaternion.identity);

            return obj;
        }
    }
}
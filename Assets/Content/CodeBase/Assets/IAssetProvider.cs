using UnityEngine;

namespace Content.CodeBase.Infrastructure.Assets
{
    public interface IAssetProvider
    {
        T Instantiate<T>(string path) where T : Object;
        T InstantiateAt<T>(string path, Vector3 at) where T : Object;
    }
}
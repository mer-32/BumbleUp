using System.Collections.Generic;
using UnityEngine;

namespace Content.CodeBase.Infrastructure.Services
{
    public interface IPlatformsManager : IService
    {
        void AddPlatform(Transform transform);
        void SwapPlatforms();
        Transform GetPlatform(int num = 0);
        Transform GetTargetPlatform();
        Vector3 GetPlatformStep();
        Vector3 GetPlatformSize();
        List<Transform> GetPlatforms();
        Vector3 GetRandomPos(float offsetX = 0);
        void Init();
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Content.CodeBase.Infrastructure.Services
{
    public interface IPlatformsFactory : IService
    {
        void CreatePlatforms();
        void SwapPlatforms();
        Vector3 JumpVector { get; }
        List<Transform> Platforms { get; }
        Vector3 PlatformSize { get; }
        Transform GetPlatform(int num = 0, bool isTargetPlatform = false);
    }
}
using Content.CodeBase.Components;
using Content.CodeBase.Data;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Infrastructure.Services
{
    public class PlayerFactory : UnitFactory
    {
        public PlayerFactory(DiContainer diContainer, IPlatformsManager platformsManager, IUnitDataService unitDataService) : 
            base(diContainer, platformsManager, unitDataService)
        {
        }
        
        public override void Create()
        {
            Unit prefab = unitDataService.GetDataUnits<PlayerData>()[PlayerType.Cylinder];

            Player player = diContainer.InstantiatePrefabForComponent<Player>(prefab,
                platformsManager.GetTargetPlatform().position, Quaternion.identity, null);

            player.Init();
        }
    }
}
using System.Collections;
using Content.CodeBase.Components;
using Content.CodeBase.Data;
using Content.CodeBase.Infrastructure.Assets;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private DiContainer _diContainer;

        private IAssetProvider _assetProvider;
        private IUnitDataService _unitDataService;
        private IPlatformsFactory _platformsFactory;
        private CoroutineRunner _coroutineRunner;

        private GameFactory(IPlatformsFactory platformsFactory, IUnitDataService unitDataService, DiContainer diContainer, CoroutineRunner coroutineRunner)
        {
            _platformsFactory = platformsFactory;
            _diContainer = diContainer;
            _unitDataService = unitDataService;
            _coroutineRunner = coroutineRunner;
            
            _assetProvider = new AssetProviderZenject(_diContainer);
            
            _unitDataService.Load();
        }

        public void CreatePlayer()
        {
            Unit prefab = _unitDataService.GetDataUnits<PlayerData>()[PlayerType.Cylinder];

            Player player = _diContainer.InstantiatePrefabForComponent<Player>(prefab,
                _platformsFactory.GetPlatform(isTargetPlatform: true).position, Quaternion.identity, null);
            
            player.Init();
        }

        public void CreateEnemy() => _coroutineRunner.StartCoroutine(CreateEnemies());
  
        public void CreatePlatforms() => _platformsFactory.CreatePlatforms();

        private IEnumerator CreateEnemies()
        {
            yield return new WaitForSeconds(Random.Range(2,5));
            
            Unit prefab = _unitDataService.GetDataUnits<EnemyData>()[(EnemyType) Random.Range(0,2)];

            Enemy enemy = _diContainer.InstantiatePrefabForComponent<Enemy>(prefab, 
                _platformsFactory.GetPlatform(9).position + GetSpawnBorders(), Quaternion.identity, null);
            
            enemy.Init();
            
            CreateEnemy();
        }

        private Vector3 GetSpawnBorders()
        {
            float halfPlatform = _platformsFactory.PlatformSize.x / 2;
            return Random.Range(-halfPlatform, halfPlatform) * Vector3.right;
        }
    }
}
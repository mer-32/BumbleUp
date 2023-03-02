using System.Collections;
using Content.CodeBase.Components;
using Content.CodeBase.Data;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Infrastructure.Services
{
    public class EnemyFactory : UnitFactory
    {
        private CoroutineRunner _coroutineRunner;

        public EnemyFactory(CoroutineRunner coroutineRunner, DiContainer diContainer,
            IPlatformsManager platformsManager, IUnitDataService unitDataService) :
            base(diContainer, platformsManager, unitDataService)
        {
            _coroutineRunner = coroutineRunner;
        }

        public override void Create() => CreateEnemy();

        private void CreateEnemy() => _coroutineRunner.StartCoroutine(CreateEnemies());

        private IEnumerator CreateEnemies()
        {
            yield return new WaitForSeconds(Random.Range(2, 5));

            Unit prefab = unitDataService.GetDataUnits<EnemyData>()[(EnemyType) Random.Range(0, 2)];

            Enemy enemy = diContainer.InstantiatePrefabForComponent<Enemy>(prefab,
                platformsManager.GetPlatform(platformsManager.GetPlatforms().Count - 1).position +
                platformsManager.GetRandomPos(),
                Quaternion.identity, null);

            enemy.Init();

            CreateEnemy();
        }
    }
}
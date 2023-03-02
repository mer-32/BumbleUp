using Content.CodeBase.Components;
using Zenject;

namespace Content.CodeBase.Infrastructure.Services
{
    public class UnitsFactory : IUnitsFactory
    {
        [Inject] private IPlatformsManager _platformsManager;
        [Inject] private DiContainer _diContainer;
        [Inject] private CoroutineRunner _coroutineRunner;
        
        private readonly IUnitDataService _unitDataService;

        private UnitsFactory(IUnitDataService unitDataService)
        {
            _unitDataService = unitDataService;
            
            _unitDataService.Load();
        }

        public void CreatePlayer() => CreateUnit(new PlayerFactory(_diContainer, _platformsManager, _unitDataService));
        
        public void CreateEnemies() => CreateUnit(new EnemyFactory(_coroutineRunner,_diContainer,_platformsManager, _unitDataService));
        
        private void CreateUnit(UnitFactory unitFactory) => unitFactory.Create();
    }
}
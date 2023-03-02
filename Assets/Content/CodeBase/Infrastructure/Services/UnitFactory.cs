using Zenject;

namespace Content.CodeBase.Infrastructure.Services
{
    public abstract class UnitFactory
    {
        protected IPlatformsManager platformsManager;
        protected IUnitDataService unitDataService;
        protected DiContainer diContainer;
        
        public UnitFactory(DiContainer diContainer, IPlatformsManager platformsManager, IUnitDataService unitDataService)
        {
            this.diContainer = diContainer;
            this.platformsManager = platformsManager;
            this.unitDataService = unitDataService;
        }
        
        public abstract void Create();
    }
}
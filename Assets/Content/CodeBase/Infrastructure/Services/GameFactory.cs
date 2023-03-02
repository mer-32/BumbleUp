namespace Content.CodeBase.Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private IPlatformsFactory _platformsFactory;
        private IUnitsFactory _unitsFactory;

        private GameFactory(IPlatformsFactory platformsFactory, IUnitsFactory unitsFactory)
        {
            _platformsFactory = platformsFactory;
            _unitsFactory = unitsFactory;
        }

        public void CreatePlayer() => _unitsFactory.CreatePlayer();

        public void CreateEnemies() => _unitsFactory.CreateEnemies();
            
        public void CreatePlatforms() => _platformsFactory.CreatePlatforms();
    }
}
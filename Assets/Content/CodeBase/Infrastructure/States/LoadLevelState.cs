using Content.CodeBase.Infrastructure.Services;

namespace Content.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            InitWorld();
        }

        public void Exit()
        {
        }

        private void InitWorld()
        {
            _gameFactory.CreatePlatforms();

            _gameFactory.CreateEnemies();

            _gameFactory.CreatePlayer();
        }
    }
}
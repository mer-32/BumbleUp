using Content.CodeBase.Infrastructure.Services;

namespace Content.CodeBase.Infrastructure.States
{
    public class GameEndState : IState
    {
        private readonly IGameFactory _gameFactory;

        public GameEndState(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            _gameFactory.CreateEnemies();
        }

        public void Exit()
        {
        }
    }
}
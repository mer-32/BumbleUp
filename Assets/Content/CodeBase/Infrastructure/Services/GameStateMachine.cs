using System;
using System.Collections.Generic;
using Content.CodeBase.Infrastructure.States;

namespace Content.CodeBase.Infrastructure
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(LoadLevelState levelState, GameLoopState loopState, GameEndState endState)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(LoadLevelState)] = levelState,
                [typeof(GameLoopState)] = loopState,
                [typeof(GameEndState)] = endState,
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();

            _activeState = _states[typeof(TState)];

            _activeState.Enter();
        }
    }
}
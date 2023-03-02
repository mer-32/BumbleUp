using Content.CodeBase.Infrastructure.States;

namespace Content.CodeBase.Infrastructure
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : IState;
    }
}
﻿namespace Content.CodeBase.Infrastructure.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
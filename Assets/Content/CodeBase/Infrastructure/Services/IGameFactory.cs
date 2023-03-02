﻿namespace Content.CodeBase.Infrastructure.Services
{
    public interface IGameFactory : IService
    {
        void CreatePlatforms();
        void CreatePlayer();
        void CreateEnemies();
    }
}
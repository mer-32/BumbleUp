namespace Content.CodeBase.Infrastructure.Services
{
    public interface IGameFactory : IService
    {
        void CreatePlayer();
        void CreatePlatforms();
        void CreateEnemy();
    }
}
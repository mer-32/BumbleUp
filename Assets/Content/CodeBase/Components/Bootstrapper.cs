using Content.CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Components
{
    public class Bootstrapper : MonoBehaviour
    {
        [Inject] private IGameFactory _gameFactory;

        private void Start()
        {
            InitWorld();
        }
        
        private void InitWorld()
        {
            _gameFactory.CreatePlatforms();
            _gameFactory.CreatePlayer();
            _gameFactory.CreateEnemy();
        }
    }
}